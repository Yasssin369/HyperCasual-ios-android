using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //public Transform goal;
    Rigidbody rb;
    LayerMask ground;
    //NavMeshAgent agent;
   [SerializeField] float speed = 0.7f;
    public Animator animator;
    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        //agent = GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
    }
    private void FixedUpdate()
    {
        
        EnemyAction();

    }
    void Update()
    {
        /*Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
        if (rb.velocity.y<0)
        {
            Destroy(gameObject);
        }*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            animator.SetBool("Fall", true);
            player.GetComponent<PlayerMovement>().Fall();
            speed = 0;

        }
    }
    public void Stopmovement()
    {

    }
    private void EnemyAction()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
        if (rb.velocity.y < -2)
        {
            Destroy(gameObject);
        }
    }
}
