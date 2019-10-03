using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_EventManager : MonoBehaviour
{
    private bool flag = false;
    private Vector3 vector3;
    private Vector2 vector2;

    void OnEnable () 
    {
        EventManager.Subscribe ("event_name", MyFunction);
    }

    void OnDisable () 
    {
        EventManager.Unsubscribe ("event_name", MyFunction);
    }

    void MyFunction (object[] parameters) 
    {
	    print ("Len = " + parameters.Length);  // количество параметров
        for(int n=0; n<parameters.Length; n++)
        {
	        print (parameters[n]);
            System.Type type_param = parameters[n].GetType();
            if(type_param == typeof(string))
            {
                print ("STRING: " + type_param);
            }
            if(type_param == typeof(int))
            {
                print ("INT: " + type_param);
            }
            if(type_param == typeof(float))
            {
                print ("FLOAT: " + type_param);
            }
        }
    }

    void Start()
    {
        vector3.x = 1;
        vector3.y = 2;
        vector3.z = 3;

        vector2.x = 1;
        vector2.y = 2;
    }

    void Update()
    {
        if(!flag)
        {
            flag = true;
            EventManager.SendEvent ("event_name", "param_string", 1, 2f);
            // EventManager.SendEvent ("event_name", vector3, vector2);
            // EventManager.SendEvent ("event_name", "test");
        }
    }
}
