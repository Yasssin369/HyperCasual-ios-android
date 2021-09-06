using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    public Collider coll;
    public Rigidbody rb;
    public float fallDelay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //StartCoroutine(Fall());
            rb.useGravity = true;
            rb.isKinematic = false;

        }
    }
  
    
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.useGravity = true;
        rb.isKinematic = false;

        yield return 0;
    }
}
