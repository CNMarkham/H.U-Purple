using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UFOLOL : MonoBehaviour
    
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float maxSpeed;
    public GameObject UFOBombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
        Vector3 velocity = rb.velocity;
        velocity = velocity + transform.right * Time.deltaTime * moveSpeed;
        if (velocity.x > 10)
        {
            velocity.x = 10; 
        }
        
        Vector3.ClampMagnitude(velocity, maxSpeed);
        rb.velocity = velocity;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(UFOBombPrefab, transform.position, transform.rotation);
        }
    }
  
}
