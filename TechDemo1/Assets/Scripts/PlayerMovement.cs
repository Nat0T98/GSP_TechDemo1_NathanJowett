using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Body;
    public float Speed;
    public float FlightSpeed;
    public float JumpModifier;
    private Animator Anim;
    private BoxCollider2D boxCollider;
   [SerializeField] private LayerMask groundLayer;
    private float horizontalInput;


    [SerializeField] private float Fuel = 100f;
    [SerializeField] private Slider FuelSlider;
    [SerializeField] private float FuelBurnRate = 20;
    [SerializeField] private float FuelRefillRate = 20;
    private bool hasFuel = true;
    private float currentFuel;

    



    private void Awake()
    {
        //Get references for rigidbody and animator
        Body = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        currentFuel = Fuel;
        
    }


    private void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        Body.velocity = new Vector2(horizontalInput*Speed, Body.velocity.y);

        FuelSlider.value = currentFuel / Fuel;
        if (currentFuel <= 0) 
        {
            hasFuel = false;
            
        }
        if(!hasFuel)
        {
            isGrounded();
           if (currentFuel >= 1)
            {
                hasFuel = true;
            }
        }


        //Flips Character when moving left/right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = Vector3.one;
        }

        if(Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jumping();
        }
        
        if(Input.GetKey(KeyCode.N) && !isGrounded() && hasFuel)
        {
            Flying();
            currentFuel -= FuelBurnRate * Time.deltaTime;
        }
        

        if(isGrounded())
        {
            RefillFuel();
        }

        //Set animator parameters
        Anim.SetBool("Run", horizontalInput != 0);
        Anim.SetBool("Grounded", isGrounded());
    }

    private void Jumping()
    {
        Body.velocity = new Vector2(Body.velocity.x, JumpModifier);
        Anim.SetTrigger("Jump");
        

    }

   private void Flying()
    {
        Body.AddForce(Vector3.up * FlightSpeed);
    }

    private void RefillFuel()
    {
        if(currentFuel < Fuel)
        {
            currentFuel += FuelRefillRate * Time.deltaTime;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
        
    }
    
    
}



