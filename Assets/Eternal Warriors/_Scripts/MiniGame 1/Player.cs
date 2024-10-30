using Eternal_Warriors._Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;

    private BoxCollider2D myCollider;

    public SpawnObject manager;

    public Stress stress;

    private Animator myAnimator;

    private TimeEnd timeEnd;

    private Health health;

    private bool gameStarted = false; //ktra co an nut space hay chua

    private bool controlsEnabled = false; //co duoc phep dieu khien hay ko
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        timeEnd = FindAnyObjectByType<TimeEnd>();
        health = FindAnyObjectByType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsEnabled)
        {
            StartGame();
            if (timeEnd._time <= 0 || health.health <= 0)
            {
                myAnimator.SetBool("is_Run", false);
            }
            else
            {
                Move();
            }
        }
    }

    private void Move()
    {
        if (!gameStarted) return;
        var VerticalInput = Input.GetAxis("Vertical");
        transform.localPosition += new Vector3(0, VerticalInput, 0) * moveSpeed * Time.deltaTime;

        //di chuyen qua phai 
        var direction = Vector3.right;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetBool("is_Run", true);
            manager.GetComponent<SpawnObject>().creatObject = true;
            stress.GetComponent<Stress>().StartStress();
            gameStarted = true;
        }
    }
    public void EnableControl(bool enabled)
    {
        controlsEnabled = enabled;
    }
    
}
