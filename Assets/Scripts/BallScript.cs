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

    public GameObject PowerupsObject;
    public GameObject PowerupGeneratorObj;
    public GameObject BasicLevelGen;

    public GameObject life;

    public GameObject paddle;

    int numBricks = 0;


    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
        velocityRef = Vector2.down * speed;

        numBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        BasicLevelGen = GameObject.Find("BasicLevelGenerator");
        
    }

    // Update is called once per frame
    void Update()
    {
        numBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        if (transform.position.y < floor)
        {
            transform.position = new Vector3(0, -1.5f, 0);
            rb.velocity = Vector2.down * speed;

            life.GetComponent<Life>().LoseLife(20);

            // set paddle x to 0
            paddle.transform.position = new Vector3(0, paddle.transform.position.y, paddle.transform.position.z);

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
            if (numBricks == 0) {
                Powerup();
            }
        }
    }

    void Powerup()
    {
        PowerupsObject.SetActive(true);
        BasicLevelGen.GetComponent<BasicLevelGenerator>().stageRoot.transform.Find("Text (TMP)").gameObject.SetActive(true);
        // transform.position = new Vector3(0, -0.5f, 0);
        // rb.velocity = Vector2.down * speed;
        // set paddle x to 0
        paddle.transform.position = new Vector3(0, paddle.transform.position.y, paddle.transform.position.z);

        gameObject.SetActive(false);
        Time.timeScale = 0;

        PowerupGeneratorObj.GetComponent<PowerupGenerator>().GeneratePowerups();
    }

    public void IncreaseSize() {
        gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0);
    }
}



}
