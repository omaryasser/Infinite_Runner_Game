using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_over : MonoBehaviour
{

    public Button start_game;
    public Button quit_game;
    void Start()
    {
        if (button_listeners.mute) GetComponent<AudioSource>().enabled = false;
        start_game.onClick.AddListener(() => { start_game_(); });
        quit_game.onClick.AddListener(() => { quit_game_(); });
    }
    public void start_game_()
    {
        SceneManager.LoadScene("Game");
    }
    public static void quit_game_()
    {
        Application.Quit();
    }
}
