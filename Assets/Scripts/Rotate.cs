using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Rotate : MonoBehaviour
{
    public bool isRotate;
    public float rotate_rate;
    private Camera cam;
    //private GameObject portrait;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //Scene scene = SceneManager.GetActiveScene();

        //foreach(GameObject obj in scene.GetRootGameObjects())
        //{
        //    if(obj.name == "Landscape")
        //    {
        //        portrait = obj;
        //    }
        //}

        if (isRotate)
        {
            RotateLeft();
        }
    }

    public void PointerDown()
    {
        isRotate = true;
    }

    public void PointerUp()
    {
        isRotate = false;
    }

    public void RotateLeft()
    {

        cam.transform.eulerAngles += new Vector3(0, 0, rotate_rate);

    }
}
