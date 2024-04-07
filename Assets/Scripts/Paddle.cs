using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Paddle : MonoBehaviour
{

    public float speed;
    public float boundry;
    float movementX;

    public int shieldNo = 0;


    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
        boundry = 11;
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxis("Horizontal");

        if ((movementX > 0 && transform.position.x < boundry) || (movementX < 0 && transform.position.x > -boundry))
        {
            transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * speed;
        }
        
    }

    // check bullet collision with paddle
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            if (shieldNo > 0)
            {
                shieldNo--;
            }
            else
            {
                GameObject.Find("life").GetComponent<Life>().LoseLife(10);
            }
        }
    }

    public void AddShield() {
        shieldNo += 2;
    }

    public void IncreasePaddleSize() {
        GameObject.Find("Paddle").transform.localScale += new Vector3(0.2f, 0, 0);
    }
}
