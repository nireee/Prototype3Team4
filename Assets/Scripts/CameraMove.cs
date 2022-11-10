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
    public float rotate_min;
    public float rotate_max;

    public float zoomOutMin;
    public float zoomOutMax;

    [SerializeField]private Vector3 minValue, maxValue;

    public GameObject statue;

    public bool AllowRotate;
    private Vector3 Rotation;
    public float rotate_speed = 10f;

    public float cur_camSize;

    public GameObject Portrait;

    public float euler_x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cur_camSize = cam.orthographicSize;
        if(cam.transform.eulerAngles.x < 329.9 && cam.transform.eulerAngles.x > 1)
        {
            euler_x = 330;
        }
        else if(cam.transform.eulerAngles.x > 0 && cam.transform.eulerAngles.x < 1)
        {
            euler_x = 360;
        }
        else
        {
            euler_x = cam.transform.eulerAngles.x;
        }
     
        Debug.Log(cam.transform.eulerAngles);
        cam.transform.rotation = Quaternion.Euler(euler_x, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);

        if (Input.GetMouseButtonDown(0))
        {
            touchpoint = cam.ScreenToWorldPoint(Input.mousePosition);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Statue")
                {
                    //Rotate
                    Debug.Log("AllowRotate");
                    AllowRotate = true;
                }
            }
            else
            {
                AllowRotate = false;
            }
        }

        if(Input.touchCount == 2)
        {

            Zoom();

        }
        //else if(Input.touchCount == 3)
        //{
        //    Tilt();
        //}

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

    //void Tilt()
    //{
    //    //Debug.Log("Tilt!");
    //    //Vector3 dir = touchpoint - cam.ScreenToWorldPoint(Input.mousePosition);

    //    //float x = -(dir.y) * tilt_rate;

    //    //cam.transform.eulerAngles += new Vector3(x, 0, 0);

    //    //cam.transform.eulerAngles = new Vector3(
    //    //    Mathf.Clamp(cam.transform.rotation.x, rotate_min, rotate_max),
    //    //    cam.transform.rotation.y,
    //    //    cam.transform.rotation.z
    //    //    );

    //    //touchpoint = cam.ScreenToWorldPoint(Input.mousePosition);
    //}

    void SetCamBoundary()
    {
        float minx = minValue.x * (cur_camSize / 4);
        float miny = minValue.y * (cur_camSize / 4);
        float minz = minValue.z * (cur_camSize / 4);
        float maxx = maxValue.x * (cur_camSize / 4);
        float maxy = maxValue.y * (cur_camSize / 4);
        float maxz = maxValue.z * (cur_camSize / 4);

        cam.transform.position = new Vector3
        (
            Mathf.Clamp(cam.transform.position.x, minx, maxx),
            Mathf.Clamp(cam.transform.position.y, miny, maxy),
            Mathf.Clamp(cam.transform.position.z, minz, maxz)
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


        cam.orthographicSize -= difference * zoom_rate;

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, zoomOutMin, zoomOutMax);

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
        //statue.transform.eulerAngles += Rotation;
        statue.transform.Rotate(Rotation);
        touchpoint = cam.ScreenToWorldPoint(Input.mousePosition);
    }



}
