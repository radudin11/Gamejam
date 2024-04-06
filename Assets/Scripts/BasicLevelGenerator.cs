using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicLevelGenerator : MonoBehaviour
{

    public Vector2Int size;
    public Vector2 offset;

    public float yRef;
    public GameObject brickPrefab;

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
        GenerateStage();
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
}
