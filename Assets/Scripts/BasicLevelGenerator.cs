using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class BasicLevelGenerator : MonoBehaviour
    {

        public Vector2Int size;
        public Vector2 offset;

        public float yRef;
        public GameObject brickPrefab;

        private void Awake()
        {
            Level l1 = new Level("./Assets/Levels/Level1.txt");
            LevelHelper.Serialize(l1, "./Assets/Levels/Level1.ser");
            LoadLevel(1);
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadLevel(int levelIndex)
        {
            // if (levelIndex == 2) size.x = 2;
            if (levelIndex >= 2)
            {
                for (int i = 0; i < size.x; i++)
                {
                    if (levelIndex == 2) size.y = 4;
                    for (int j = 0; j < size.y; j++)
                    {
                        Vector2 spawnPosition = new Vector2((((float)size.x - 1) * .5f - i) * offset.x, j * offset.y + yRef);
                        Instantiate(brickPrefab, spawnPosition, Quaternion.identity);
                    }
                }
            }
            else
            {
                Level l = LevelHelper.Deserialize("./Assets/Levels/Level" +  levelIndex + ".ser");
                float deltaX = (float)((l.y * 1 + 0.25 * (l.y - 1)) / 2.0);
                float deltaY = (float)((l.x * 1 + 0.125 * (l.x - 1)) / 2.0);
                for (int i = 0; i < l.x; i ++)
                {
                    for (int j = 0; j < l.y; j++)
                    {
                        if (l.grid[i, j] == 1)
                        {
                            Vector2 spawnPosition = new Vector2((float)(j * 1 + 0.25 * (j - 1)) - deltaX, (float)(i * 0.5f + 0.25 * (i - 1)) - deltaY);
                            Debug.Log(spawnPosition);
                            Instantiate(brickPrefab, spawnPosition, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}
