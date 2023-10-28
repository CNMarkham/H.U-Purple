using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }
}
