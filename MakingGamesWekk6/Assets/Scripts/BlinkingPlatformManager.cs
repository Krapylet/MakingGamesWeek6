using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingPlatformManager : MonoBehaviour
{

    float timer = 0.5f;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            timer = 0.5f;

            if (boxCollider2D.enabled == true)
            {
                boxCollider2D.enabled = false;
                spriteRenderer.enabled = false;
            }    
            else
            {
                boxCollider2D.enabled = true;
                spriteRenderer.enabled = true;
            }
            
        }
    }
}
