using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            print("You win!");
            //SceneManager.LoadScene ("YouWin");
            collision.gameObject.SendMessage("You_Win");
        }
    }
}
