using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timelapse : MonoBehaviour
{
    public Button phase1;
    public Button phase2;
    public Button phase3;
    public Button phase4;

    private Camera cam;
    public bool isRotate;
    
    private SceneControl cur_scene;

    public static Timelapse staticTimelapse;
    // Start is called before the first frame update
    void Start()
    {
        if (staticTimelapse == null)
        {
            DontDestroyOnLoad(transform.root.gameObject);
            staticTimelapse = this;
        }
        else
        {
            Destroy(gameObject);
        }

        phase2.interactable = false;
        phase3.interactable = false;
        phase4.interactable = false;

        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        cur_scene = FindObjectOfType<SceneControl>();
        if (cur_scene.countdown == 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            int scene_index = scene.buildIndex + 1;
            if (scene_index == 1)
            {
                phase2.interactable = true;
            }
            if (scene_index == 2)
            {
                phase2.interactable = true;
                phase3.interactable = true;
            }
            if (scene_index == 3)
            {
                phase2.interactable = true;
                phase3.interactable = true;
                phase4.interactable = true;
            }
        }
    }

    public void Phase1()
    {
        SceneManager.LoadScene(0);

    }
    public void Phase2()
    {
        SceneManager.LoadScene(1);

    }
    public void Phase3()
    {
        SceneManager.LoadScene(2);

    }
    public void Phase4()
    {
        SceneManager.LoadScene(3);

    }

   
}
