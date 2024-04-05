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

    private void Awake()
    {
        for (int i = 0; i < size.x; i ++) {
            for (int j = 0; j < size.y; j++) {
                Vector2 spawnPosition = new Vector2((((float)size.x - 1)*.5f- i) * offset.x, j * offset.y + yRef);
                Instantiate(brickPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
