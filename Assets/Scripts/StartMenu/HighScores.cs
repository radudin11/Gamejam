using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighScores : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        gameObject.transform.Find("Image").GetComponent<UnityEngine.UI.Image>().color -= new Color(0.2f, 0.2f, 0.2f, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
        gameObject.transform.Find("Image").GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1);
    }

    public void HighScoresMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HighscoresMenu");
    }
}
