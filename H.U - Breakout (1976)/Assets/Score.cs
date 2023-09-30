using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }
    //"OnCollisionEnter2D" event  : this event runs when the object collides with something else. 
    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  Destroy(collision.gameObject);
        // code below for short checking if the tag of the object is brick 1.
        if (collision.gameObject.CompareTag("Brick (1)"))
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = score.ToString();
        }
}
            
        }

    