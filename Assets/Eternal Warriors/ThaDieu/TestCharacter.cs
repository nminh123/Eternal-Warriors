using UnityEngine;


public class TestCharacter : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public TestKite kite;
    public float speed;
    private float xInput;
    public float distance = 2f;
    //public Joystick joystick;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (KiteEnd.instance.isOpenUI) return;
        if (!kite.isWindActive)
        {
            CheckInput();
        }
        CheckDistance();
        CheckAnimation();
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        Flip(xInput);
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        //JoyStickk();
    }
    public void CheckAnimation()
    {
        if (xInput != 0)
            anim.SetBool("move", true);
        else
            anim.SetBool("move", false);
    }
    public void Flip(float x)
    {
        if (x > 0)
            this.transform.localScale = new Vector3(1, 1, 1);
        else if (x < 0)
            this.transform.localScale = new Vector3(-1, 1, 1);
    }

    private void CheckDistance()
    {
        float xDistance = Mathf.Abs(transform.position.x - kite.transform.position.x);

        if (!kite.isWindActive && xDistance > distance)
        {
            Vector2 direction = (transform.position.x - kite.transform.position.x > 0) ? Vector2.right : Vector2.left;
            kite.transform.position += (Vector3)direction * (xDistance - distance);
        }
    }
    //public void JoyStickk()
    //{
    //    xInput = joystick.Horizontal;
    //    Vector2 movement = new Vector2(xInput, 0) * speed * 2 * Time.deltaTime;
    //    rb.MovePosition(rb.position + movement);
    //    Flip(movement.x);
    //}
}
