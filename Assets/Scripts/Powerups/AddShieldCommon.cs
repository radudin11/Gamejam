using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game {
    public class AddShieldCommon : Powerup {
        public override void Use() {
            // add shield
            GameObject.Find("Paddle").GetComponent<Paddle>().AddShield();
            // start next level
            GameObject.Find("BasicLevelGenerator").GetComponent<BasicLevelGenerator>().GenerateLevel();
            GameObject[] powerups = GameObject.FindGameObjectsWithTag("powerup");
            foreach (GameObject powerup in powerups) {
                Destroy(powerup);
            }
            Time.timeScale = 1;
            GameObject powerupPanel = GameObject.Find("Powerup");
            powerupPanel.SetActive(false);
            // get all powerups
            
        }
    }
}