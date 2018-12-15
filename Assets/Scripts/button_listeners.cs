using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button_listeners : MonoBehaviour
{

    public Button start_game;
    public Button options;
    public Button mute_sound;
    public Text mute_text;
    public Button how_to_play;
    public Button credits;
    public Button back, back_how_to_play, back_credits;
    public Canvas menu_canvas, options_canvas, how_to_play_canvas, credits_canvas;
    public static bool mute = false;
    void Start()
    {
        menu_canvas.enabled = true;
        options_canvas.enabled = false;
        how_to_play_canvas.enabled = false;
        credits_canvas.enabled = false;
        start_game.onClick.AddListener(() => { start_game_(); });
        options.onClick.AddListener(() => { options_(); });
        mute_sound.onClick.AddListener(() => { mute_sound_(); });
        how_to_play.onClick.AddListener(() => { toggle_how_to_play(); });
        back_how_to_play.onClick.AddListener(() => { toggle_how_to_play(); });
        credits.onClick.AddListener(() => { toggle_credits(); });
        back.onClick.AddListener(() => { back_(); });
        back_credits.onClick.AddListener(() => { toggle_credits(); });
    }

    public void toggle_credits()
    {
        options_canvas.enabled = !options_canvas.enabled;
        credits_canvas.enabled = !credits_canvas.enabled;
    }
    public void start_game_()
    {
        SceneManager.LoadScene("Game");
    }
    public static void game_over()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void options_()
    {
        menu_canvas.enabled = !menu_canvas.enabled;
        options_canvas.enabled = !options_canvas.enabled;
    }
    public void mute_sound_()
    {
        mute = !mute;
        if (mute)
        {
            GetComponent<AudioSource>().enabled = false;
            mute_text.text = "Unmute";
        }
        else
        {
            GetComponent<AudioSource>().enabled = true;
            mute_text.text = "Mute";
        }
    }
    void toggle_how_to_play()
    {
        options_canvas.enabled = !options_canvas.enabled;
        how_to_play_canvas.enabled = !how_to_play_canvas.enabled;
    }

    public void credits_()
    {
        SceneManager.LoadScene("Credits");
    }
    public void back_()
    {
        menu_canvas.enabled = !menu_canvas.enabled;
        options_canvas.enabled = !options_canvas.enabled;
    }
}
