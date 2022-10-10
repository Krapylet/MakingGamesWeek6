using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 8f;
    private float hori;
    private bool isfacingRight = true;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        hori = Input.GetAxisRaw("Horizontal");
        Flip();
        //Jump();

    }


    void FixedUpdate (){
        rb.velocity = new Vector2(hori*movementSpeed, rb.velocity.y);
    }
    void Flip()
    {
        
        if (isfacingRight && hori < 0f || !isfacingRight && hori > 0f) {
            isfacingRight = !isfacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        } 
    }

}
