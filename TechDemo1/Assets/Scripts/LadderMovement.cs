using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    private float Vertical;
    public float speed;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        Vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(Vertical) > 0f)
        {
            isClimbing = true;
        }
        else isClimbing = false;
    }

    private void FixedUpdate()
    {
        if(isClimbing)
        {
            rb.gravityScale = 3f;
            rb.velocity = new Vector2 (rb.velocity.x, Vertical * speed);
        }
        else
        {
            rb.gravityScale = 1f;

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true; Debug.Log("HIT");
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }


}
