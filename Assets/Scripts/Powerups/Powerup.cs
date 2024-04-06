using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Game {
    public class Powerup: MonoBehaviour {
        public enum Type {
            Common, Rare, Epic, Legendary
        };

        public Type rarity;
        public GameObject stageGenerator;

        public void Start() {
            stageGenerator = GameObject.Find("BasicLevelGenerator");
        }

        public void Use() {
            Apply();
            stageGenerator.GetComponent<BasicLevelGenerator>().NextStage();
        }

        public virtual void Apply() {
            Debug.Log("Stub");
        }

        public void Update() {
    
        }
    };
}