using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;


public class Paddle : MonoBehaviour
{

    public float speed;
    public float boundry;
    float movementX;

    public int shieldNo = 0;
    public GameObject shieldObj;

    public float cooldown = 0.5f;

    private AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip shieldSound;


    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
        boundry = 11;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        } else {
            movementX = Input.GetAxis("Horizontal");

            if ((movementX > 0 && transform.position.x < boundry) || (movementX < 0 && transform.position.x > -boundry))
            {
                transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * speed;
            }
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
                audioSource.PlayOneShot(shieldSound);
                shieldNo--;
            }
            else
            {
                audioSource.PlayOneShot(hitSound);
                GameObject.Find("life").GetComponent<Life>().LoseLife(10);
                shieldObj.SetActive(false);
            }
        }
    }

    public void AddShield() {
        shieldNo += 2;
        shieldObj.SetActive(true);
    }

    public void IncreasePaddleSize() {
        GameObject.Find("Paddle").transform.localScale += new Vector3(0.2f, 0, 0);
    }
}
