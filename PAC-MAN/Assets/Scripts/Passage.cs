
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    public Transform teleportPosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 tempPos = teleportPosition.position;
        tempPos.z = collision.transform.position.z;
        collision.transform.position = tempPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
