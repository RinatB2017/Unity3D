using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;

public class EventManager : MonoBehaviour 
{
	[Serializable]
	public class GameEvent : UnityEvent <string> {};	// Наше новое событие с параметром			
	private static EventManager _eventManager;								
	private Dictionary <string, GameEvent> _eventDictionary;				

	public static EventManager instance 
	{
		get {
			if (!_eventManager) 
			{
				_eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;
				if (!_eventManager) 
					 Debug.LogError ("There needs to be one active EventManger...");
				else 
					_eventManager.Init (); 
			}
			return _eventManager;
		}
	}

	void Init () 
	{
		if (_eventDictionary == null)
			_eventDictionary = new Dictionary<string, GameEvent>();
	}

	public static void StartListening (string eventName, UnityAction <string> listener) 
	{
		GameEvent thisEvent = null;
		if (instance._eventDictionary.TryGetValue (eventName, out thisEvent))
			thisEvent.AddListener (listener);
		else {
			thisEvent = new GameEvent ();
			thisEvent.AddListener (listener);
			instance._eventDictionary.Add (eventName, thisEvent);
		}
	}
		
	public static void StopListening (string eventName,  UnityAction <string> listener) 
	{
		if (_eventManager == null) 
			return;
		GameEvent thisEvent = null;
		if (instance._eventDictionary.TryGetValue (eventName, out thisEvent))
			thisEvent.RemoveListener (listener);
	}

	public static void SendEvent (string eventName, string param = null) 
	{
		GameEvent thisEvent = null;
		if (instance._eventDictionary.TryGetValue (eventName, out thisEvent))
			thisEvent.Invoke (param);	// Вызов и передача параметра
	}
}
