using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public float floor = -5.0f;
    public float speed = 8.0f;

    Vector2 velocityRef; 

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
        velocityRef = Vector2.down * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < floor)
        {
            transform.position = new Vector3(0, 1, 0);
            rb.velocity = Vector2.down * speed;
        }

        if (rb.velocity.magnitude != velocityRef.magnitude){
            rb.velocity = rb.velocity.normalized * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        { 
            Destroy(collision.gameObject);
        }
    }
}
