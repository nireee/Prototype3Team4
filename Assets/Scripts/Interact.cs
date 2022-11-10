using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Camera cam;
    public bool Touched;
    public GameObject TextPanel;
    public bool Exist;
    // Start is called before the first frame update
    void Start()
    {
        TextPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfInfoExist();
        CheckTouchTag();
        if (Touched)
        {
            Debug.Log("Instantiate!");
            TextPanel.SetActive(true);
        }
        if (TextPanel.GetComponent<TextWindow>().HasExit == true && Touched == true)
        {
            
            Debug.Log("quit!");
            TextPanel.GetComponent<TextWindow>().HasExit = false;
            Touched = false;
            TextPanel.SetActive(false);
        }
    }

    void CheckTouchTag()
    {
        if (Input.GetMouseButtonDown(0) && !Exist)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    Touched = true;
                }
            }

        }
    }

    public void CheckIfInfoExist()
    {
        if (GameObject.FindWithTag("TextWindow"))
        {
            Exist = true;
        }
        else
        {
            Exist = false;
        }
    }

    //void Reposition()
    //{
    //    if (Touched)
    //    {
    //        cam.ScreenToWorldPoint(Input.mousePosition);
    //        Touched = false;
    //    }
    //}
}
