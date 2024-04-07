using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    void Start()
    {
        score = PlayerPrefs.GetInt("score");

        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Your score: " + score;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    
}
