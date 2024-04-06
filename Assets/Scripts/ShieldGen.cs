using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGen : MonoBehaviour
{

    public GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        int noOfShields = GameObject.Find("Paddle").GetComponent<Paddle>().shieldNo;
        GameObject grid = GameObject.Find("shields");
        for (int i = 0; i < noOfShields; i++) {
            Instantiate(shield, grid.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
