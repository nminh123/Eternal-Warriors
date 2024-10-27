using Eternal_Warriors._Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;

    private BoxCollider2D myCollider;

    public SpawnObject manager;

    public Stress stress;

    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        StartGame();
    }

    private void Move()
    {
        var VerticalInput = Input.GetAxis("Vertical");
        transform.localPosition += new Vector3(0, VerticalInput, 0) * moveSpeed * Time.deltaTime;
    }

    private void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetBool("is_Run", true);
            manager.GetComponent<SpawnObject>().creatObject = true;
            stress.GetComponent<Stress>().StartStress();
        }
    }
}
