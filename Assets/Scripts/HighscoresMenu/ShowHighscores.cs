using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ShowHighscores : MonoBehaviour
{
    struct pair {
        public string x;
        public int y;

        public pair(string x, int y)
        {
            this.x = x;
            this.y = y;
        }
    };
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";

        List<pair> highscores = new List<pair>();
        // open csv file
        string path = "./highscores.csv";

        // check if file exists
        if (!System.IO.File.Exists(path)) {
            return;
        }
        string[] lines = System.IO.File.ReadAllLines(path);

        // read each line
        foreach (string line in lines) {
            string[] entries = line.Split(',');
            highscores.Add(new pair(entries[0], int.Parse(entries[1])));
        }

        highscores.Sort((a, b) => b.y.CompareTo(a.y));

        for (int i = 0; i < 10 && i < highscores.Count; i++) {
            int place = i + 1;
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text += place.ToString() + ". " + highscores[i].x + " - " + highscores[i].y + "\n";
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
