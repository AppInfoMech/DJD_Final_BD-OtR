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

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; 
    }

    // Update is called once per frame
    void Update()
    {
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
