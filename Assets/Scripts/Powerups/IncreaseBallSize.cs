using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game {
    public class IncreaseBallSize : Powerup {
        public override void Apply() {
            // add shield
            GameObject.Find("BasicLevelGenerator").GetComponent<BasicLevelGenerator>().ball.GetComponent<BallScript>().IncreaseSize();
        }
    }
}