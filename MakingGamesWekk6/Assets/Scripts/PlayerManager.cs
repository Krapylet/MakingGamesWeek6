using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //Miscellaneous
    int groundLayer = 1 << 12;
    Vector2 footpositionSx;
    Vector2 footpositionDx;

    //stats
    public float speed;
    public float jumpForce;
    bool canjump;
    bool spinta;
    public bool glitch = false;
    bool glitchJump = false;
    bool glitchTimerbool = false;
    float m_power = 0;
    Vector2 m_direction;
    public float reposition = 2;
    public float resetPower = 2f;
    float glitchTimer = 0.5f;
    public float glichPower = 300;

    //componenti
    public GameObject Piedi;
    public Rigidbody2D Rigidbody;
    public BoxCollider2D boxCollider2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    public AudioClip glitchClip;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LevelTest")
        {
            glitch = false;
        }
        else
        {
            glitch = true;
        }
    }

    enum State
    {
        Idle,
        Walk,
        Jump,
        Falling,
        Glitch
    }

    PlayerManager.State m_state = PlayerManager.State.Idle;


    // Update is called once per frame
    void Update()
    {
        if(spriteRenderer.flipX)
        {
            reposition = 50f;
        }
        else
        {
            reposition = -50f;
        }


        footpositionSx = new Vector2(Piedi.transform.position.x - 4, Piedi.transform.position.y);
        footpositionDx = new Vector2(Piedi.transform.position.x + 4, Piedi.transform.position.y);
        
        if(glitchTimerbool)
        {
            glitchTimer -= Time.deltaTime;
        }    

        if(glitchTimer < 0)
        {
            //audioSource.PlayOneShot(glitchClip);
            transform.position = new Vector3(transform.position.x + reposition,  transform.position.y, transform.position.z);
            glitchJump = true;
            glitchTimerbool = false;
            glitchTimer = 0.5f;
        }

            //Jump
                if (canjump)
                {
                    glitchJump = false;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if(glitch)
                        {
                             glitchTimerbool = true;
                        }
                        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Rigidbody.velocity.y + jumpForce);
                    }
                }

        //Walk
        Rigidbody.velocity = new Vector2 (Input.GetAxis("Horizontal") * speed + m_power * m_direction.x, Rigidbody.velocity.y);

        //GroundDetection
        if (Physics2D.Raycast(footpositionSx, Vector2.down, 1f, groundLayer) || Physics2D.Raycast(footpositionDx, Vector2.down, 1f, groundLayer))
        {
            canjump = true;
        }
        else
        {
            canjump = false;
        }

        //AnimationManager

        if (Rigidbody.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (Rigidbody.velocity.x > 0)
        {
            spriteRenderer.flipX = false;

        }

        if(glitchJump)
        {
            m_state = PlayerManager.State.Glitch;
        }
        else if(Rigidbody.velocity.y == 0.0f)
        { 
            if (Rigidbody.velocity.x == 0.0f)
            {
                 m_state = PlayerManager.State.Idle;
            }
            else
            {
               m_state = PlayerManager.State.Walk;
            }
        }
        else //animazioni in aria
        {
            if(Rigidbody.velocity.y > 0)
            {
                m_state = PlayerManager.State.Jump;
            }
            else if(Rigidbody.velocity.y < 0)
            {
                m_state = PlayerManager.State.Falling;
            }
            
        }
        

        switch (m_state)
        {
            case PlayerManager.State.Idle:

                //idle
                animator.Play("Idle");
                break;

            case PlayerManager.State.Glitch:

                //idle
                animator.Play("Glitch");
                break;

            case PlayerManager.State.Walk:

                //walk
                animator.Play("Walk");
                break;

            case PlayerManager.State.Jump:

                //jump
                animator.Play("Jump");
                break;

            case PlayerManager.State.Falling:

                //walk
                animator.Play("Falling");
                break;
        }
  
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "death")
        {
            SceneManager.LoadScene("LevelTest");
        }
    }

}

