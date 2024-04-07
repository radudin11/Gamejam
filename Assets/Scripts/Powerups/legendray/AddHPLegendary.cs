using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game {
    public class AddHPLegendary : Powerup {
        public override void Apply() {
            // add 15 HP
            GameObject.Find("life").GetComponent<Life>().AddPermanentLife(75);
        }
    }
}