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
            print("You lost!");
            SceneManager.LoadScene ("YouLost");
        }
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
