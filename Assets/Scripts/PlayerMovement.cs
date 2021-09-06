using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Touch touch;
    public LevelManager levelManager;
    public float speed = 0.6f;
    public float sensitivity = 0.2f;
    public Rigidbody rb;

    public Vector2 startPos;
    public Vector2 direction;
    public Vector3 forwardMove;
    public Animator animator;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }
    private void FixedUpdate()
    {
        PlayerMovements();
        if (rb.velocity.y < -2)
        {
            Fall();
        }

    }

    void Update()
    {
        if (levelManager.loadCount == 1 && Input.touchCount == 1)
        {
            
                levelManager.GameStart();
            
        }
       
    }
    public void FinishLine()
    {
        animator.SetBool("Win", true);
        speed = 0;
    }
    public void Fall()
    {
        animator.SetBool("Dead", true);
        speed = 0;
        levelManager.GameOver();

    }
    private void PlayerMovements()
    {
         forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
        if (Input.touchCount > 0)
        {

            float target;
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (touchPosition.x > Screen.width / 2)
            {
                target = 1;
            }
            else
            {
                target = -1;
            }
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                transform.position += Vector3.right * target * sensitivity * Time.fixedDeltaTime;
                transform.position += transform.forward * speed * Time.fixedDeltaTime;
            }


        }
            
    }
}
