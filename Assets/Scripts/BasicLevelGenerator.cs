using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicLevelGenerator : MonoBehaviour
{

    public Vector2Int size;
    public Vector2 offset;

    public float yRef;
    public GameObject brickPrefab;

    public GameObject canvas;
    public GameObject stageRoot;

    private void Awake()
    {
        //for (int i = 0; i < size.x; i ++) {
        //    for (int j = 0; j < size.y; j++) {
        //        Vector2 spawnPosition = new Vector2((((float)size.x - 1)*.5f- i) * offset.x, j * offset.y + yRef);
        //        Instantiate(brickPrefab, spawnPosition, Quaternion.identity);
        //    }
        //}
        
    }





    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        stageRoot = GameObject.Find("StageRoot");
        Rect r = stageRoot.GetComponent<RectTransform>().rect;
        Level l = new Level(5, 10, 0.8, 0.1);
        DrawLevel(l);
        //Debug.Log(r.width + " " + r.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DrawLevel(Level level)
    {
        double brickWidth;
        double brickHeight;
        double offsetX;
        double offsetY;

        Rect r = stageRoot.GetComponent<RectTransform>().rect;
        if (0.58 * r.height / level.x  > 0.86 * r.width / 2 / level.y)
        {
            brickHeight = 0.5 * r.height/ level.x;
            brickWidth = 2 * brickHeight;

            offsetY = 0.08 * r.height / (level.x - 1);
            offsetX = (0.96 * r.width - level.y * brickWidth) / (level.y - 1);
        } else
        {
            brickWidth = 0.8 * r.width/ level.y;
            brickHeight = brickWidth / 2;

            offsetX = 0.06 * r.width / (level.y - 1);
            offsetY = (0.58 * r.height - level.x * brickHeight) / (level.x - 1);
        }

        Debug.Log(r.width + ", " + r.height);
        Debug.Log(brickWidth + " " + brickHeight + " " + offsetX + " " + offsetY);
        Debug.Log((brickWidth * level.y + offsetX * (level.y - 1)) + " " + (brickHeight + level.x + offsetY * (level.x - 1)));

        Vector2 anchor = stageRoot.GetComponent<RectTransform>().anchoredPosition;
        double startY = anchor.y - r.height / 2 + 0.4 * r.height + brickHeight / 2;
        for (int i = 0; i <  level.x; i++)
        {
            double startX = anchor.x - r.width / 2 + 0.02 * r.width + brickWidth / 2;
            for (int j = 0; j < level.y; j++)
            {
                if (level.grid[i, j] != 0)
                {
                 
                    Vector2 spawnPosition = new Vector2((float)startX, (float)startY);
                    //Debug.Log(spawnPosition.x + " " + spawnPosition.y);
                    GameObject o = Instantiate(brickPrefab, spawnPosition, Quaternion.identity, stageRoot.transform);
                    o.transform.localPosition = spawnPosition;
                    o.transform.localScale = new Vector2((float)brickWidth, (float)brickHeight);
                }
                startX += brickWidth + offsetX;
            }
            startY += brickHeight + offsetY;
        }
    }
}
