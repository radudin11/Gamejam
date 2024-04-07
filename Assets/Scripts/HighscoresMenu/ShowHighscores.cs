using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHighscores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";

        // open csv file
        string path = "Assets/Highscores/highscores.csv";
        string[] lines = System.IO.File.ReadAllLines(path);

        // read each line
        int place = 1;
        foreach (string line in lines) {
            string[] entries = line.Split(',');
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text += place.ToString() + ". " + entries[0] + " - " + entries[1] + "\n";
            place++;
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
