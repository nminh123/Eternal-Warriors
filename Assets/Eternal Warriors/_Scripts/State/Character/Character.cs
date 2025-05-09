using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;
    [SerializeField]protected float speed;

    public Joystick joystick;

    protected void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    protected void Update()
    {
        this.CheckInput();
        this.SetAnimation();
        //JoyStickk();
    }
    protected void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        SetVelocity(xInput, yInput);
        //JoyStickk();
       
    }
    protected void SetVelocity(float x,float y)
    {   
        rb.velocity = new Vector3(x,y).normalized * speed;
        Flip(x);
    }
    protected void Flip(float x)
    {
        if (x > 0)
            this.transform.localScale = new Vector3(1, 1, 1);
        else if(x < 0)
            this.transform.localScale = new Vector3(-1, 1, 1);
    }

    protected void SetAnimation()
    {
        if (xInput != 0 || yInput != 0)
            anim.SetBool("move", true);
        else if(xInput == 0 || yInput == 0)
            anim.SetBool("move",false);
    }
    public void JoyStickk()
    {
        xInput = joystick.Horizontal;
        yInput = joystick.Vertical;
        Vector2 movement = new Vector2 (xInput, yInput)* speed *2 * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        Flip(movement.x);
    }
}
