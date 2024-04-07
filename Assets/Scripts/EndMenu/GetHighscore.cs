using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetHighscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHighscoreName() {
        string text = gameObject.GetComponent<TMP_InputField>().text;

        int score = PlayerPrefs.GetInt("score");

        // add score and name to csv file

        string path = "Assets/Highscores/highscores.csv";
        System.IO.StreamWriter file = new System.IO.StreamWriter(path, true);
        file.WriteLine(text + "," + score.ToString());
        file.Close();
    }
}
