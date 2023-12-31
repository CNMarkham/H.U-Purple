using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float lookSpeed;
    public float moveSpeed;
    public float maxSpeed;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;

   // public string Name;

   // public Player(string name, float health)
   // {
   //     Name = name;
   // }

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * lookSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * lookSpeed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 velocity = rb.velocity;
            velocity = velocity + transform.right * Time.deltaTime * moveSpeed;
            if (velocity.x > 10)
            {
                velocity.x = 10;
            }
            Vector3.ClampMagnitude(velocity, maxSpeed);
            rb.velocity = velocity;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }



        }
