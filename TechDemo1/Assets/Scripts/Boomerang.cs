using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float BoomerangSpeed;
    private Rigidbody2D BoomerangRB;
   

    void Start()
    {
        BoomerangRB = GetComponent<Rigidbody2D>();
        BoomerangRB.velocity = transform.right * BoomerangSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
