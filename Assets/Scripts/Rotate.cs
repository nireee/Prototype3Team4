using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool isRotate_left;
    public bool isRotate_right;
    public float rotate_rate;

    private GameObject portrait;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        portrait = GameObject.Find("Landscape");

        if (isRotate_left)
        {
            RotateLeft();
        }
        if (isRotate_right)
        {
            RotateRight();
        }
    }

    public void PointerDown_left()
    {
        isRotate_left = true;
    }

    public void PointerUp_left()
    {
        isRotate_left = false;
    }

    public void PointerDown_right()
    {
        isRotate_right = true;
    }

    public void PointerUp_right()
    {
        isRotate_right = false;
    }

    public void RotateLeft()
    {

        portrait.transform.Rotate(0, rotate_rate, 0, Space.Self);

    }
    public void RotateRight()
    {

        portrait.transform.Rotate(0, -rotate_rate, 0, Space.Self);

    }
}
