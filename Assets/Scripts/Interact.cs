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
        Touched = false;
        TextPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouchTag();
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
                if (hit.transform.tag == "InteractObj")
                {
                    Touched = true;
                    TextPanel.SetActive(Touched);
                    Touched = false;
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
