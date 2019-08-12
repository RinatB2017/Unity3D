using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeep : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //запускаем функцию MoveToBegin без параметров
            collision.gameObject.SendMessage("MoveToBegin");
        }
    }
}
