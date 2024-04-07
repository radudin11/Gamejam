using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Life : MonoBehaviour
{

    public int currentLife = 100;
    public int maxLife = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
            if (currentLife <= 0)
            {
                // game over
                Debug.Log("Game Over");
            }
        
    }

    public void LoseLife(int amount)
    {
        currentLife -= amount;
    }

    public void AddPermanentLife(int amount)
    {
        maxLife += amount;
        currentLife += amount;
    }


}
