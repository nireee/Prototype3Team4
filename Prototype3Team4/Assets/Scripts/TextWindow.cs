using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWindow : MonoBehaviour
{

    public GameObject TextPanel;
    //public Text content;


    // Start is called before the first frame update
    void Start()
    {
        TextPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void DisplayText(string s)
    //{
    //    content.text = s;

    //}

    public void ShowText()
    {
        TextPanel.SetActive(true);
    }

    public void HideText()
    {
        TextPanel.SetActive(false);
    }
}
