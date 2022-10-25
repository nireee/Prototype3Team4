using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SubCamera : MonoBehaviour
{
    public Vector3 touchpoint;
    public Camera cam;

    public Vector2 touch0_prev;
    public Vector2 touch1_prev;
    public float prev_magnitude;
    public float cur_magnitude;
    public float difference;
    public float zoom_rate = 0.01f;

    public float zoomOutMin = 10f;
    public float zoomOutMax = 100f;

    public GameObject statue;

    public bool ThisCam;

    public bool AllowRotate;
    private Vector3 Rotation;
    public float rotate_speed;
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
        }



        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            touch0_prev = touch0.position - touch0.deltaPosition;
            touch1_prev = touch1.position - touch1.deltaPosition;

            prev_magnitude = (touch0_prev - touch1_prev).magnitude;
            cur_magnitude = (touch0.position - touch1.position).magnitude;

            difference = cur_magnitude - prev_magnitude;

            Zoom(difference * zoom_rate);
        }
        else if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Statue")
                {
                    //Rotate
                    AllowRotate = true;
                }
            }

            //if (EventSystem.current.IsPointerOverGameObject())
            //{
            //    ThisCam = true;
            //    Debug.Log("subcam area");
            //}
            //else
            //{
            //    ThisCam = false;
            //    Debug.Log("maincam area");
            //}

            if (AllowRotate)
            {
                RotateStatue();
            }

        }
    }

    void Zoom(float diff)
    {
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - diff, zoomOutMin, zoomOutMax);
    }

    void RotateStatue()
    {
        Debug.Log("Rotate!");
        Vector3 dir = touchpoint - cam.ScreenToWorldPoint(Input.mousePosition);
        Rotation.y = -(dir.x) * rotate_speed;
        Rotation.x = -(dir.y) * rotate_speed;
        statue.transform.eulerAngles += Rotation;
        touchpoint = cam.ScreenToWorldPoint(Input.mousePosition);
    }

}
