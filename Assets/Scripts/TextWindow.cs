using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWindow : MonoBehaviour
{

    public GameObject TextPanel;
    public GameObject choice1;
    public GameObject choice2;
    public GameObject result;
    public TextMeshProUGUI ResultPanel;
    [TextArea] public string Result1;
    [TextArea] public string Result2;
    public bool CorrectIsChoice1;
    public bool HasExit;
    public bool ChoiceMade;


    // Start is called before the first frame update
    void Start()
    {
        TextPanel.SetActive(false);
        result.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowText()
    {
        TextPanel.SetActive(true);
    }

    public void HideText()
    {
        TextPanel.SetActive(false);
        HasExit = true;
    }

    public void Choice1()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        result.SetActive(true);
        DisplayAnswer(Result1);
        ChoiceMade = true;
        SetCorrectResultColor();
    }

    public void Choice2()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        result.SetActive(true);
        DisplayAnswer(Result2);
        ChoiceMade = true;
        SetCorrectResultColor();

    }

    public void DisplayAnswer(string ans)
    {
        ResultPanel.text = ans;
    }

    //have to preset whether CorrectIsChoice1 is true or not
    public void SetCorrectResultColor()
    {
        if (CorrectIsChoice1 == true)
        {
            ResultPanel.color = Color.green;
        }
        else if(CorrectIsChoice1 == false)
        {
            ResultPanel.color = Color.red;
            
        }
    }
}
