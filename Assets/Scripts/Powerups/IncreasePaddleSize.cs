using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game {
    public class IncreasePaddleSize : Powerup {
        public override void Apply() {
            // add shield
            GameObject.Find("Paddle").GetComponent<Paddle>().IncreasePaddleSize();
        }
    }
}