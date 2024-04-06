using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game {

public class BallScript : MonoBehaviour
{

    public float floor = -5.0f;
    public float speed = 8.0f;

    Vector2 velocityRef; 

    public GameObject powerupPanel;

    public GameObject PowerupGeneratorObj;

    public GameObject life;

    public GameObject paddle;

    public int numBricks = 0;


    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
        velocityRef = Vector2.down * speed;

        numBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        
        Time.timeScale = 1;
        GetComponent<Transform>().position = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (numBricks == 0)
        {
            Powerup();
            NextLevel();
        } else {
            if (transform.position.y < floor)
            {
                transform.position = new Vector3(0, 1, 0);
                rb.velocity = Vector2.down * speed;

                life.GetComponent<Life>().LoseLife(20);

                // set paddle x to 0
                paddle.transform.position = new Vector3(0, paddle.transform.position.y, paddle.transform.position.z);

            }
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
            numBricks--;
        }
    }

    void Powerup()
    {
        //powerupPanel.SetActive(true);
        Time.timeScale = 0;

        //PowerupGeneratorObj.GetComponent<PowerupGenerator>().GeneratePowerups();

        // Destroy(gameObject);

        BasicLevelGenerator b = GameObject.FindFirstObjectByType<BasicLevelGenerator>();
        b.LoadLevel(2);
        Start();

    }

    void NextLevel()
    {

    }
}

}
