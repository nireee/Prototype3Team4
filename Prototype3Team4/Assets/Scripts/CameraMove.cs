using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 touchpoint;
    public Camera cam;

    public Vector2 touch0_prev;
    public Vector2 touch1_prev;
    public float prev_magnitude;
    public float cur_magnitude;
    public float difference;
    public float zoom_rate = 5f;

    public float rot;
    public float tilt_rate;
    public float rotate_min = -180f;
    public float rotate_max = 180f;

    public float zoomOutMin_x = 25f;
    public float zoomOutMax_x = 100f;

    public float zoomOutMin_y = 10f;
    public float zoomOutMax_y = 40f;


    public GameObject statue;

    public bool AllowRotate;
    private Vector3 Rotation;
    public float rotate_speed = 10f;

    public GameObject Portrait;
    public Vector3 cur_scale;

    public float LeftLimit;
    public float RightLimit;
    public float TopLimit;
    public float BottomLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchpoint = cam.ScreenToWorldPoint(Input.mousePosition);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Statue")
                {
                    //Rotate
                    AllowRotate = true;
                }
                else
                {
                    AllowRotate = false;
                }
            }
        }

        if(Input.touchCount == 2)
        {

            Zoom();

        }
        else if(Input.touchCount == 3)
        {
            Tilt();
        }

        else if (Input.GetMouseButton(0))
        {
            if (AllowRotate)
            {
                RotateStatue();
            }
            else
            {
                DragPortrait();
                
            }
        }
    }

    void Tilt()
    {
        Vector3 dir = touchpoint - cam.ScreenToWorldPoint(Input.mousePosition);

        float x = -(dir.y) * tilt_rate;

        Portrait.transform.eulerAngles += new Vector3(x, Portrait.transform.rotation.y, Portrait.transform.rotation.z);

        touchpoint = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void Rotate()
    {
        Touch touch0 = Input.GetTouch(0);
        Touch touch1 = Input.GetTouch(1);

        touch0_prev = touch0.position - touch0.deltaPosition;
        touch1_prev = touch1.position - touch1.deltaPosition;

        Vector2 prev_dir = touch0_prev - touch1_prev;
        Vector2 cur_dir = touch0.position - touch1.position;

        rot = Vector2.Angle(prev_dir, cur_dir);

        Portrait.transform.eulerAngles += Rotation;

        Debug.Log("Rotate!");

    }

    void SetCamBoundary()
    {
        cam.transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, LeftLimit, RightLimit),
            Mathf.Clamp(transform.position.y, BottomLimit, TopLimit),
            cam.transform.position.z
        );
    }

    void Zoom()
    {
        Touch touch0 = Input.GetTouch(0);
        Touch touch1 = Input.GetTouch(1);

        touch0_prev = touch0.position - touch0.deltaPosition;
        touch1_prev = touch1.position - touch1.deltaPosition;

        prev_magnitude = (touch0_prev - touch1_prev).magnitude;
        cur_magnitude = (touch0.position - touch1.position).magnitude;

        difference = cur_magnitude - prev_magnitude;
        

        cur_scale = Portrait.transform.localScale;
        cur_scale.x = Mathf.Clamp(Portrait.transform.localScale.x + (2.5f*difference*zoom_rate), zoomOutMin_x, zoomOutMax_x);
        cur_scale.y = Mathf.Clamp(Portrait.transform.localScale.y + (difference*zoom_rate), zoomOutMin_y, zoomOutMax_y);

        float factor = cur_scale.x / Portrait.transform.localScale.x;

        LeftLimit *= factor;
        RightLimit *= factor;
        TopLimit *= factor;
        BottomLimit *= factor;

        Portrait.transform.localScale = cur_scale;

        Debug.Log("Zoom!");

    }

    void DragPortrait()
    {
        Vector3 dir = touchpoint - cam.ScreenToWorldPoint(Input.mousePosition);
        dir.z = 0;
        cam.transform.position += dir;
        SetCamBoundary();
    }

    void RotateStatue()
    {
        Debug.Log("Rotate!");
        Vector3 dir = touchpoint - cam.ScreenToWorldPoint(Input.mousePosition);
        Rotation.y = (dir.x) * rotate_speed;
        Rotation.x = -(dir.y) * rotate_speed;
        statue.transform.eulerAngles += Rotation;
        touchpoint = cam.ScreenToWorldPoint(Input.mousePosition);
    }



}
