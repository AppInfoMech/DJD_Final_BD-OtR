using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public AudioSource jump;

    public bool isGrounded
    {
        get
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, 100, LayerMask.GetMask("Ground"));

            if (collider != null) return true;

            return false;
        }
    }

    public float jumpVelocity = 270f;
    public float highJumpVelocity = 310f;
    public float moveSpeed = 5f;
    public float jumpTime = 0.35f;
    public float timeOfJump;
    public bool running;

    Rigidbody2D rgdBody;

    void Awake()
    {
        rgdBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        timeOfJump = -1000.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = rgdBody.velocity;

        if (currentVelocity.x > 0)
        {
            running = true;
            
        }
        else if (currentVelocity.x == 0)
        {
            running = false;
        }

        animator.SetFloat("VelY", currentVelocity.y);
        animator.SetFloat("VelX", currentVelocity.x);
        animator.SetBool("isRunning", running);
        animator.SetBool("isGrounded", isGrounded);
        // Vector3 movement = new Vector3(5f, 0f, 0f);
        // transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void FixedUpdate()
    {
        Vector2 currentVelocity = rgdBody.velocity;

        currentVelocity = new Vector2(moveSpeed, currentVelocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                currentVelocity.y = jumpVelocity;
                timeOfJump = Time.time;
                jump.Play();
            }
            
        }
        else if (Input.GetButton("Jump"))
        {
            if ((Time.time - timeOfJump) < jumpTime)
            {
                currentVelocity.y = jumpVelocity;
            }
        }
        else
        {
            timeOfJump = -1000.0f;
        }

        rgdBody.velocity = currentVelocity;
    }

    void OnTriggerEnter2D(Collider2D cutscene)
    {
        if(cutscene.gameObject.tag == "Cutscene")
        {
            moveSpeed = 0f;
        }
    }
}
