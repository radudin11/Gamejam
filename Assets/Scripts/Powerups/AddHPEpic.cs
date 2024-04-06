using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game {
    public class AddHPEpic : Powerup {
        public override void Use() {
            // add 15 HP
            GameObject.Find("life").GetComponent<Life>().AddPermanentLife(50);
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