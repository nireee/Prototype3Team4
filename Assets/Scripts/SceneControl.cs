using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneControl : MonoBehaviour
{
    public int countdown;
    public TextMeshProUGUI CountDownPanel;
    public GameObject[] TextWindows;
    public bool[] Checked;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < TextWindows.Length; i++)
        {
            countdown++;
            Checked[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfChoiceMade();
        CountDownPanel.text = "Points left: " + countdown.ToString();
    }

    void CheckIfChoiceMade()
    {
        for (int i = 0; i < TextWindows.Length; i++)
        {
            if(TextWindows[i].GetComponent<TextWindow>().ChoiceMade == true && Checked[i] == false)
            {
                Checked[i] = true;
                countdown--;
            }
        }
    }



}
