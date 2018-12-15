using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class start_controller : MonoBehaviour
{

    public GameObject[] tiles;
    public Camera[] cameras;
    GameObject[] pause_objects;
    Color[] colors;
    public Button resume_button, restart_button, quit_button, pause_android, camera_android;
    public Canvas android_canvas;
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
            android_canvas.enabled = false;
        colors = new Color[3];
        colors[0] = new Color(236f / 256, 6f / 256, 6f / 256);
        colors[1] = new Color(6f / 256, 236f / 256, 6f / 256);
        colors[2] = new Color(6f / 256, 6f / 256, 236f / 256);
        resume_button.onClick.AddListener(() => { resume_button_(); });
        restart_button.onClick.AddListener(() => { restart_button_(); });
        quit_button.onClick.AddListener(() => { quit_button_(); });
        pause_android.onClick.AddListener(() => { pause_android_(); });
        camera_android.onClick.AddListener(() => { camera_android_(); });
        pause_objects = GameObject.FindGameObjectsWithTag("show_on_pause");
        hide_paused();
        cameras[0].enabled = true;
        cameras[1].enabled = false;
        
        foreach (GameObject tile in tiles)
        {
            tile.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
        }
    }

    private void camera_android_()
    {
        foreach (Camera camera in cameras)
        {
            camera.enabled = !camera.enabled;
        }
    }

    private void pause_android_()
    {
        toggle_pause();
    }
    private void quit_button_()
    {
        Application.Quit(); 
    }

    private void restart_button_()
    {
        restart();
    }

    private void resume_button_()
    {
        toggle_pause();
    }

    public void toggle_pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            show_paused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hide_paused();
        }
    }

    public void show_paused()
    {
        foreach (GameObject game_object in pause_objects)
        {
            game_object.SetActive(true);
        }
    }

    public void hide_paused()
    {
        foreach (GameObject game_object in pause_objects)
        {
            game_object.SetActive(false);
        }
    }

    public void restart()
    {
        toggle_pause();
        SceneManager.LoadScene("Game");
    }

    private void FixedUpdate()
    {
        foreach (Camera c in cameras) {
            c.backgroundColor = colors[player_controller.cur_color];
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach (Camera camera in cameras)
            {
                camera.enabled = !camera.enabled;
            }
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle_pause();
        }
    }
}
