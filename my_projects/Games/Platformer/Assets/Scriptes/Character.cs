using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    private int cnt = -1;
    private int s_width = 0;
    private int s_height = 0;
    private bool f_left  = false;
    private bool f_right = false;
    private bool f_jump  = false;
    
    public int lives = 3;
    public float speed = 4.0f;
    public float jumpforce = 1.0f;
    public Rigidbody2D PlayerRigidbody;
    public Animator charAnimator;
    public SpriteRenderer sprite;

    public float beginX = -5f;
    public float beginY = -2f;
    public float beginZ = 0;
    
    private Vector2 old_position;
    private Vector2 new_position;
    
    public Image btn_left;
    public Image btn_right;
    public Image btn_jump;
    
    public Rect rect_left;
    public Rect rect_right;
    public Rect rect_jump;

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
    
    void debug_print(string text)
    {
        print(text);
    }

    void Awake()
    {
        s_width  = Screen.width;
        s_height = Screen.height;
        debug_print("width  " + s_width);
        debug_print("height " + s_height);

        PlayerRigidbody = GetComponentInChildren<Rigidbody2D>();
        charAnimator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        rect_left.x = btn_left.rectTransform.localPosition.x;
        rect_left.y = btn_left.rectTransform.localPosition.y;
        rect_left.width = btn_left.rectTransform.rect.width;
        rect_left.height = btn_left.rectTransform.rect.height;

        rect_right.x = btn_right.rectTransform.localPosition.x;
        rect_right.y = btn_right.rectTransform.localPosition.y;
        rect_right.width = btn_right.rectTransform.rect.width;
        rect_right.height = btn_right.rectTransform.rect.height;
        
        rect_jump.x = btn_jump.rectTransform.localPosition.x;
        rect_jump.y = btn_jump.rectTransform.localPosition.y;
        rect_jump.width = btn_jump.rectTransform.rect.width;
        rect_jump.height = btn_jump.rectTransform.rect.height;
    }
    
    bool check_btn_left(float x, float y)
    {
        float x1 = rect_left.x;
        float y1 = rect_left.y;
        float x2 = x1 + rect_left.width;
        float y2 = y1 - rect_left.height;

        if(x < x1)  return false;
        if(x > x2)  return false;
        if(y > y1)  return false;
        if(y < y2)  return false;

        debug_print("click left");
        return true;
    }
    
    bool check_btn_right(float x, float y)
    {
        float x1 = rect_right.x;
        float y1 = rect_right.y;
        float x2 = x1 + rect_right.width;
        float y2 = y1 - rect_right.height;

        if(x < x1)  return false;
        if(x > x2)  return false;
        if(y > y1)  return false;
        if(y < y2)  return false;

        debug_print("click right");
        return true;
    }

    bool check_btn_jump(float x, float y)
    {
        float x1 = rect_jump.x;
        float y1 = rect_jump.y;
        float x2 = x1 + rect_jump.width;
        float y2 = y1 - rect_jump.height;

        if(x < x1)  return false;
        if(x > x2)  return false;
        if(y > y1)  return false;
        if(y < y2)  return false;

        debug_print("click up");
        return true;
    }
    
    bool is_pressed_left()
    {
        cnt = Input.touchCount;
        if(cnt == 0)
        {
            return false;
        }
        Touch[] myTouch = Input.touches;
        float x = 0f;
        float y = 0f;
        for (int i = 0; i < cnt; ++i)
        {
            x = myTouch[i].position.x - s_width / 2f;
            y = myTouch[i].position.y - s_height / 2f;

            if(check_btn_left(x, y)) return true;
        }        
        return false;
    }

    bool is_pressed_right()
    {
        cnt = Input.touchCount;
        if(cnt == 0)
        {
            return false;
        }
        Touch[] myTouch = Input.touches;
        float x = 0f;
        float y = 0f;
        for (int i = 0; i < cnt; ++i)
        {
            x = myTouch[i].position.x - s_width / 2f;
            y = myTouch[i].position.y - s_height / 2f;

            if(check_btn_right(x, y)) return true;
        }        
        return false;
    }

    bool is_pressed_jump()
    {
        cnt = Input.touchCount;
        if(cnt == 0)
        {
            return false;
        }
        Touch[] myTouch = Input.touches;
        float x = 0f;
        float y = 0f;
        for (int i = 0; i < cnt; ++i)
        {
            x = myTouch[i].position.x - s_width / 2f;
            y = myTouch[i].position.y - s_height / 2f;

            if(check_btn_jump(x, y)) return true;
        }        
        return false;
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
        
        //---
        f_left  = is_pressed_left();
        f_right = is_pressed_right();
        f_jump  = is_pressed_jump();

        if(f_left)  print("LEFT");
        if(f_right) print("RIGHT");
        if(f_jump)  print("JUMP");
        
        if(f_left || f_right)
        {
            debug_print("FFF");
            state |= 0x02;
        }
        else
            state &= ~0x02;
        
        if(f_jump)
            state |= 0x04;
        else
            state &= ~0x04;
        //---

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
