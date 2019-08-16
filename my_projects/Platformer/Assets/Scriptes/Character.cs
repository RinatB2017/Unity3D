using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int lives = 3;
    public float speed = 4.0f;
    public float jumpforce = 1.0f;
    public Rigidbody2D PlayerRigidbody;
    public Animator charAnimator;
    public SpriteRenderer sprite;

    public float beginX = -5f;
    public float beginY = -2f;
    public float beginZ = 0;

    public GameObject you_lost;
    public GameObject you_win;

    //private int old_state = 0;

    enum States
    {
        NONE = 0,
        MOVE = 1,
        JUMP = 2        
    }

    enum Keys
    {
        jhg = 0,
        jhG = 1,
        jHg = 2,
        jHG = 3,
        Jhg = 4,
        JhG = 5,
        JHg = 6,
        JHG = 7
    }

    void Awake()
    {
        PlayerRigidbody = GetComponentInChildren<Rigidbody2D>();
        charAnimator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void MoveToBegin() 
    {
        lives --;
        if(lives > 0)
        {
            transform.position = new Vector3(beginX, beginY, beginZ);
        }
        else
        {
            You_Lost();
        }
    }

    void You_Win()
    {
        print("You Win!");
        //SceneManager.LoadScene ("YouWin");
        you_win.SetActive(true);
    }

    void You_Lost() 
    {
        print("You lost!");
        //SceneManager.LoadScene ("YouLost");
        you_lost.SetActive(true);
    }

    void Move() 
    {
        Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);
        sprite.flipX = (tempvector.x < 0);
    }

    void Jump()
    {
        PlayerRigidbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }

    bool CheckGround() 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        return (colliders.Length > 1);
    }

    void Update()
    {
        int state = 0;
        if(CheckGround())
            state |= 0x01;
        else
            state &= ~0x01;

        if(Input.GetButton("Horizontal"))
            state |= 0x02;
        else
            state &= ~0x02;
            
        if(Input.GetButton("Jump"))
            state |= 0x04;
        else
            state &= ~0x04;

        /*
        if(old_state != state)
        {
            print(state);
            old_state = state;
        }
        */

        switch (state)
        {
            case (int)Keys.jhg: charAnimator.SetInteger("State", (int)States.NONE);         break;
            case (int)Keys.jhG: charAnimator.SetInteger("State", (int)States.NONE);         break;
            case (int)Keys.jHg: charAnimator.SetInteger("State", (int)States.NONE);         break;
            case (int)Keys.jHG: charAnimator.SetInteger("State", (int)States.MOVE); Move(); break;
            case (int)Keys.Jhg: charAnimator.SetInteger("State", (int)States.JUMP);         break;
            case (int)Keys.JhG: charAnimator.SetInteger("State", (int)States.JUMP); Jump(); break;
            case (int)Keys.JHg: charAnimator.SetInteger("State", (int)States.MOVE); Move(); break;
            case (int)Keys.JHG: charAnimator.SetInteger("State", (int)States.JUMP); Jump(); break;

            // case 1: charAnimator.SetInteger("State", (int)States.NONE);          break;
            // case 2: charAnimator.SetInteger("State", (int)States.NONE);          break;
            // case 2: charAnimator.SetInteger("State", (int)States.NONE);          break;
            // case 3: charAnimator.SetInteger("State", (int)States.MOVE);  Move(); break;
            // case 4: charAnimator.SetInteger("State", (int)States.JUMP);          break;
            // case 5: charAnimator.SetInteger("State", (int)States.JUMP);  Jump(); break;
            // case 6: charAnimator.SetInteger("State", (int)States.MOVE);  Move(); break;
            // case 7: charAnimator.SetInteger("State", (int)States.JUMP);  Jump(); break;

            default:
                print("state = " + state);
                break;
        }
    }

    void Update2()
    {
        if(Input.GetButton("Horizontal"))
        {
            charAnimator.SetInteger("State", 1);
            Move();
        }
        if(CheckGround() && Input.GetButton("Jump"))
        {
            charAnimator.SetInteger("State", 2);
            Jump();
        }
        if(!Input.anyKey)
        {
            charAnimator.SetInteger("State", 0);
        }
    }
}
