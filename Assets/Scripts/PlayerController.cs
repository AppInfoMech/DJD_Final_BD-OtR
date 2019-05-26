using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public bool isGrounded;
    public LayerMask groundLayers;
    public float jumpForce = 200f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; 
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        Jump();
        // Vector3 movement = new Vector3(5f, 0f, 0f);
        // transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 118.41825f,
            transform.position.y - 118.41825f), new Vector2(transform.position.x + 118.41825f,
                transform.position.y + 118.41825f), groundLayers);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Obstacle"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
