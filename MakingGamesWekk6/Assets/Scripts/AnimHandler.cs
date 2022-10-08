using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHandler : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationHandler();
    }
    private void AnimationHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
            if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.A))
            {
                anim.SetBool("jumped", true);
                anim.SetBool("isWalking_r", false);
            }
        }
        else
        {
            anim.SetBool("jumped", false);
        }
        // if statements that handles our player character sprite animations
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // checks if the the key is held down. if it returns true it sets boolean inside Unity editor to true
            // these special booleans are used for conditions in the Unity editor to transition between different sprite animations
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                anim.SetBool("isWalking_r", true);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("jumped", true);
                anim.SetBool("isWalking_r", false);
            }
            anim.SetBool("keepWalking", true);
        }
        else
        {
            anim.SetBool("isWalking_r", false);
            anim.SetBool("keepWalking", false);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            anim.SetBool("jumped", false);
            anim.SetBool("isIdle", true);
        }
    }
}
