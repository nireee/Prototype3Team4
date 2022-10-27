using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Camera cam;
    public bool Touched;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouchTag();
        Debug.Log(Touched);
        //Reposition();
    }

    void CheckTouchTag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "InteractObj")
                {
                    Touched = !Touched;
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
