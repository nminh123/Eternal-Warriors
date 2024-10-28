using UnityEngine;
using UnityEngine.TextCore.Text;

public class TestKite : MonoBehaviour
{
    public TestCharacter character;
    public float distance;
    public float followSpeed = 5f;
    public bool isWindActive;
    private Rigidbody2D rb;
    public bool isZoned;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isWindActive = false;
    }

    void Update()
    {
        if (KiteEnd.instance.isOpenUI) return;
        CheckDistance();
        CheckInput();
    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(rb.velocity.x,50));
        }
    }
    public void ApplyWindForce(float direction, float windForce)
    {
        isWindActive = true;
        rb.velocity = new Vector2(direction * windForce, 0);
        character.Flip(direction);
        Invoke(nameof(StopWind), 1f); 
    }

    private void StopWind()
    {
        isWindActive = false;
        rb.velocity = Vector2.zero;
    }

    private void CheckDistance()
    {
        float xDistance = Mathf.Abs(transform.position.x - character.transform.position.x);

        if (!isWindActive && xDistance > distance)
        {
            Vector3 targetPosition = new Vector3(
                character.transform.position.x +
                ((transform.position.x > character.transform.position.x) ? distance : -distance),
                transform.position.y,
                transform.position.z
            );

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
        else if (isWindActive && xDistance > distance)
        {
            Vector3 targetPosition = new Vector3(
                transform.position.x + ((character.transform.position.x > transform.position.x) ? -distance : distance),
                character.transform.position.y,
                character.transform.position.z
            );
            character.transform.position = Vector3.Lerp(character.transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("zone"))
        {
            isZoned = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("zone"))
        {
            isZoned = false;
        }
    }
}
