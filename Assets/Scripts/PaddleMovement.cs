using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{

    public float speed;
    public float boundry;
    float movementX;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
        boundry = 9.5f;
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
}
