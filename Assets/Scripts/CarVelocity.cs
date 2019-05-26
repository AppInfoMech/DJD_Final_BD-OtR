using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarVelocity : MonoBehaviour
{
    public float carSpeed = 7f;
    private Rigidbody2D car;
    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        car = this.GetComponent<Rigidbody2D>();
        car.velocity = new Vector2(-carSpeed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,
            Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < Camera.main.transform.position.x - 
            screenBounds.x * 2)
        {
            Destroy(this.gameObject);
            Debug.Log("Car destroyed");
        }
    }
}
