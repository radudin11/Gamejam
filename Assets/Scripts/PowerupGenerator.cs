using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
public class PowerupGenerator : MonoBehaviour
{
    public GameObject[] common;
    public GameObject[] rare;
    public GameObject[] epic;
    public GameObject[] legendary;

    GameObject powerupGrid;

    // public Vector2[] pos = {new Vector2(259.9999f, -271.5464f), new Vector2(0, 0), new Vector2(2, 0, 0)};

    public void GeneratePowerups()
    {
        powerupGrid = GameObject.Find("Powerups");
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
                GameObject card = Instantiate(common[randIndex], powerupGrid.transform);
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        // load powerups
        // common = Resources.LoadAll<GameObject>("./Assets/Prefabs/powerups/common");
        // rare = Resources.LoadAll<GameObject>("./Scripts/Powerups/rare");
        // epic = Resources.LoadAll<GameObject>("./Assets/Prefabs/Powerups/epic");
        // legendary = Resources.LoadAll<GameObject>("./Powerups/legendary");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

}
