using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    public bool tilt_up;
    public bool tilt_down;
    public float tilt_rate;
    private Camera cam;
    public float rotate_min = -60f;
    public float rotate_max = -12.362f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (tilt_up)
        {
            Debug.Log("TILT UP!");
            cam.transform.eulerAngles += new Vector3(-tilt_rate, 0, 0);

        }
        if (tilt_down)
        {
            Debug.Log("TILT DOWN!");
            cam.transform.eulerAngles += new Vector3(tilt_rate, 0, 0);

        }
    }

    public void PointerDown_Up()
    {
        tilt_up = true;
    }

    public void PointerUp_Up()
    {
        tilt_up = false;
    }
    public void PointerDown_Down()
    {
        tilt_down = true;
    }

    public void PointerUp_Down()
    {
        tilt_down = false;
    }


}
