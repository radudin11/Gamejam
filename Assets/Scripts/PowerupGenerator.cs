using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
public class PowerupGenerator : MonoBehaviour
{
    public Powerup[] common;
    public Powerup[] rare;
    public Powerup[] epic;
    public Powerup[] legendary;

    public GameObject powerupGrid;

    public void GeneratePowerups()
    {
        // generate 3 random powerups
        for (int i = 0; i < 3; i ++) {
            float rarity = Random.Range(0.0f, 1.0f);
            
            if (rarity < 0.1f) {
                int randIndex = Random.Range(0, legendary.Length);
                Instantiate(legendary[randIndex], new Vector3(0, 0, 0), Quaternion.identity, powerupGrid.transform).SetActive(true);
            } else if (rarity < 0.2f) {
                int randIndex = Random.Range(0, epic.Length);
                Instantiate(epic[randIndex], new Vector3(0, 0, 0), Quaternion.identity, powerupGrid.transform).SetActive(true);
            } else if (rarity < 0.6f) {
                int randIndex = Random.Range(0, rare.Length);
                Instantiate(rare[randIndex], new Vector3(0, 0, 0), Quaternion.identity, powerupGrid.transform).SetActive(true);
            } else {
                int randIndex = Random.Range(0, common.Length);
                Instantiate(common[randIndex], new Vector3(0, 0, 0), Quaternion.identity, powerupGrid.transform).SetActive(true);
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
}

}
