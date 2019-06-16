using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator enemyAnimator;

    //public bool isGrounded
    //{
    //    get
    //    {
    //        Collider2D collider = Physics2D.OverlapCircle(transform.position, 100, LayerMask.GetMask("Ground"));

    //        if (collider != null) return true;

    //        return false;
    //    }
    //}

    public float jumpForce = 270f;
    public float moveSpeed = 5f;

    Rigidbody2D enemyRigidbody;

    void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = enemyRigidbody.velocity;

        enemyAnimator.SetFloat("VelY", currentVelocity.y);
        // enemyAnimator.SetBool("isGrounded", isGrounded);
        // Vector3 movement = new Vector3(5f, 0f, 0f);
        // transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void FixedUpdate()
    {
        Vector2 currentVelocity = enemyRigidbody.velocity;

        currentVelocity = new Vector2(moveSpeed, currentVelocity.y);

        //if (Input.GetButtonDown("Submit") && isGrounded)
        //{
        //    currentVelocity.y = jumpForce;
        //}

        enemyRigidbody.velocity = currentVelocity;
    }

    void OnTriggerEnter2D(Collider2D disable)
    {
        if(disable.gameObject.tag == "EnemyDisable")
        {
            gameObject.SetActive(false);
        }
    }
}