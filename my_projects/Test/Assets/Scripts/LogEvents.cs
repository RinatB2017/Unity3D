using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogEvents : MonoBehaviour {

    void print_log (string text) {
        Debug.Log (text + "\n");
    }

    void OnEnable () {
        print_log ("OnEnable");
    }
    void OnDisable () {
        print_log ("OnDisable");
    }
    void OnGUI () {
        print_log ("OnGUI");
    }
    void OnApplicationPause () {
        print_log ("OnApplicationPause");
    }
    void OnApplicationQuit () {
        print_log ("OnApplicationQuit");
    }
}