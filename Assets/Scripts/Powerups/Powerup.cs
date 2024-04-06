using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Game {
    public abstract class Powerup: MonoBehaviour {
        public enum Type {
            Common, Rare, Epic, Legendary
        };

        public Type rarity;

        public abstract void Use();
    };
}