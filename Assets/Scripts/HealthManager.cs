using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public Image healthbar;
    public float healthAmount;
    public float maxHealth = 100f;

    public GameObject life;

    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        life = GameObject.Find("life");
        text = life.transform.Find("Text (TMP)").gameObject;
        healthbar = life.transform.Find("Green").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthAmount = life.GetComponent<Life>().currentLife;
        maxHealth = life.GetComponent<Life>().maxLife;
    
        healthbar.fillAmount = healthAmount / maxHealth;
        text.GetComponent<TMPro.TextMeshProUGUI>().text = healthAmount.ToString() + "/" + maxHealth.ToString();

        
    }
}
