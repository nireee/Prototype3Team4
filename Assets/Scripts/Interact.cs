using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Camera cam;
    public bool Touched;
    public GameObject TextPanel;
    // Start is called before the first frame update
    void Start()
    {
        TextPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouchTag();
        if (Touched)
        {
            TextPanel.SetActive(true);
        }
        else
        {
            TextPanel.SetActive(false);
        }
        if (TextPanel.GetComponent<TextWindow>().HasExit == true)
        {
            TextPanel.GetComponent<TextWindow>().HasExit = false;
            Touched = false;
        }
        //Reposition();
    }

    void CheckTouchTag()
    {
        if (Input.GetMouseButtonDown(0))
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

    //void Reposition()
    //{
    //    if (Touched)
    //    {
    //        cam.ScreenToWorldPoint(Input.mousePosition);
    //        Touched = false;
    //    }
    //}
}
