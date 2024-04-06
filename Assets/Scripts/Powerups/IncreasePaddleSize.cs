using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game {
    public class IncreasePaddleSize : Powerup {
        public override void Use() {
            // add shield
            GameObject.Find("Paddle").GetComponent<Paddle>().IncreasePaddleSize();
            // start next level
            GameObject.Find("BasicLevelGenerator").GetComponent<BasicLevelGenerator>().GenerateLevel();
            // get all powerups
            GameObject[] powerups = GameObject.FindGameObjectsWithTag("powerup");
            foreach (GameObject powerup in powerups) {
                Destroy(powerup);
            }
            Time.timeScale = 1;
            GameObject powerupPanel = GameObject.Find("Powerup");
            powerupPanel.SetActive(false);

            
        }
    }
}