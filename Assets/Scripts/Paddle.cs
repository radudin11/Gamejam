using System.Collections;
using System.Collections.Generic;
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

    public void AddShield() {
        shieldNo++;
        if (shieldNo > 3){
            shieldNo = 3;
        }
    }
}
