using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGen : MonoBehaviour
{

    public GameObject shield;

    public int shieldNo = 0;

    public void GenerateShields() {
        GameObject grid = GameObject.Find("ShieldGrid");
        for (int i = 0; i < shieldNo; i++) {
            Instantiate(shield, grid.transform);
        }
    }

    public void DestroyShields() {
        GameObject grid = GameObject.Find("ShieldGrid");
        foreach (Transform child in grid.transform) {
            Destroy(child.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int newShieldNo = GameObject.Find("Paddle").GetComponent<Paddle>().shieldNo;
        if (shieldNo != newShieldNo) {
            shieldNo = newShieldNo;
            DestroyShields();
            GenerateShields();
        }
        
    }
}
