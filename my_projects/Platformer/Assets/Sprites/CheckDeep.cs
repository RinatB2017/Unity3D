using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeep : MonoBehaviour
{
    // public Character player;

    // void Awake()
    // {
    //     player = GetComponent<Character>();
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //запускаем функцию MoveToBegin без параметров
            collision.gameObject.SendMessage("MoveToBegin");
        }
    }
}
