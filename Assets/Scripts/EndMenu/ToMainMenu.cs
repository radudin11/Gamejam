using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu() {

        string text = GameObject.Find("Input").GetComponent<TMP_InputField>().text;

        int score = PlayerPrefs.GetInt("score");

        Debug.Log("Score: " + score);
        Debug.Log("Name: " + text);

        if (text != "") {
            // add score and name to csv file
            string path = "./highscores.csv";
            System.IO.StreamWriter file = new System.IO.StreamWriter(path, true);
            file.WriteLine(text + "," + score.ToString());
            file.Close();
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
}
