using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game{
public class BasicLevelGenerator : MonoBehaviour
{

    public Vector2Int size;
    public Vector2 offset;

    public float yRef;
    public GameObject brickPrefab;
    public GameObject iceBrickPrefab;

    public GameObject enemy;

    private void Awake()
    {
        for (int i = 0; i < size.x; i ++) {
            for (int j = 0; j < size.y; j++) {
                Vector2 spawnPosition = new Vector2((((float)size.x - 1)*.5f- i) * offset.x, j * offset.y + yRef);
                Instantiate(brickPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    public GameObject canvas;
    public GameObject ball;
    public GameObject stageRoot;
    private GameObject newRoot;

    private GameObject text;
    private bool stageIsMoving = false;
    private float stageMoveSpeed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        stageRoot = GameObject.Find("StageRoot");
        ball = GameObject.Find("Ball");

    }

    void GenerateStage() {

        
        

        // generate stage
        for (int i = 0; i < size.x; i++) {
            for (int j = 0; j < size.y; j++) {
                Vector2 spawnPosition = new Vector2((((float)size.x - 1) * .5f - i) * offset.x, j * offset.y + yRef);
                Instantiate(brickPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    public void NextStage() {
        newRoot = Instantiate(stageRoot);
        Transform powerupsPanel = newRoot.transform.Find("Powerups");
        powerupsPanel.gameObject.SetActive(false);  
        text = newRoot.transform.Find("Text (TMP)").gameObject;
        text.gameObject.SetActive(false);

        ball.GetComponent<BallScript>().PowerupsObject = powerupsPanel.gameObject;
        // destroy chilren
        foreach (Transform child in powerupsPanel) {
            Destroy(child.gameObject);
        }
        RectTransform newRootRect = newRoot.GetComponent<RectTransform>();
        newRoot.transform.SetParent(canvas.transform);
        newRoot.transform.position = stageRoot.transform.position;
        newRoot.transform.localScale = Vector3.one;
        newRootRect.sizeDelta = stageRoot.GetComponent<RectTransform>().sizeDelta;
        Vector3 newRootPos = stageRoot.transform.position + 
            new Vector3(0, stageRoot.GetComponent<RectTransform>().rect.height, 0);
        newRootRect.anchoredPosition = newRootPos;
        // stage generation
        // GenerateStage();
        DrawLevel(new Level(5, 10, 0.8f, 0.1f), newRoot);
        stageIsMoving = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update() {
        RectTransform stageRootRect = stageRoot.GetComponent<RectTransform>();
        if (stageIsMoving) {
            RectTransform newRootRect = newRoot.GetComponent<RectTransform>();
            if (newRootRect.anchoredPosition.y > 0) {
                Vector2 newRootPos = newRootRect.anchoredPosition - Vector2.up * stageMoveSpeed * Time.deltaTime;
                newRootRect.anchoredPosition = newRootPos;
                Vector2 newStagePos = stageRootRect.anchoredPosition - Vector2.up * stageMoveSpeed * Time.deltaTime;
                stageRootRect.anchoredPosition = newStagePos;
            } else {
                stageIsMoving = false;
                Destroy(stageRoot);
                stageRoot = newRoot;
                stageRoot.name = "StageRoot";
                ball.transform.position = new Vector3(0, -1, 0);
                ball.SetActive(true);
                ball.GetComponent<Rigidbody2D>().velocity = Vector2.down * ball.GetComponent<BallScript>().speed;
            }
        }
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DrawLevel(Level level, GameObject stageRoot)
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

    Vector2 anchor = Vector2.zero; // stageRoot.GetComponent<RectTransform>().anchoredPosition;
    double startY = anchor.y + r.height / 2 - 0.02 * r.height - brickHeight / 2;
    for (int i = 0; i <  level.x; i++)
    {
        double startX = anchor.x - r.width / 2 + 0.02 * r.width + brickWidth / 2;
        for (int j = 0; j < level.y; j++)
        {
            if (level.grid[i, j] == 10)
            {
             
                Vector2 spawnPosition = new Vector2((float)startX, (float)startY);
                //Debug.Log(spawnPosition.x + " " + spawnPosition.y);
                float rand = Random.Range(0.0f, 1.0f);
                GameObject o;
                if (rand < 0.3f) {
                    o = Instantiate(iceBrickPrefab, spawnPosition, Quaternion.identity, stageRoot.transform);
                } else {
                    o = Instantiate(brickPrefab, spawnPosition, Quaternion.identity, stageRoot.transform);
                }
                o.transform.localPosition = spawnPosition;
                o.transform.localScale = new Vector2((float)brickWidth, (float)brickHeight);
            } else if (level.grid[i, j] == 100)
            {
                Vector3 spawnPosition = new Vector3((float)startX, (float)startY, -5);
                GameObject o = Instantiate(enemy, spawnPosition, Quaternion.identity, stageRoot.transform);
                o.transform.localPosition = spawnPosition;
                o.transform.localScale = new Vector2((float)brickWidth, (float)brickHeight);

            }
            startX += brickWidth + offsetX;
        }
        startY -= brickHeight + offsetY;
    }

            //level.printGrid();
}
}
}
