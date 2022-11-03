using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneControl : MonoBehaviour
{
    public int countdown;
    public TextMeshProUGUI CountDownPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDownPanel.text = "Points left: " + countdown.ToString();
    }

}
