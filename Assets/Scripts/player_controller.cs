using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour {

    public static float speed = -10;
    public AudioClip good_pick, bad_pick, zone_entrance;
    Dictionary<string,int> map = new Dictionary<string, int>();
    public static int cur_color = 0;
    public Material[] materials;
    public Light flash;
    bool increased;
    public Text text;
    int score = 0;
    int tile = 0;
    bool ready_to_change = true;
    float time = 0;
    public Camera main_camera;

    void Start () {
        if (button_listeners.mute) main_camera.GetComponent<AudioSource>().enabled = false;
        flash.enabled = false;
        map.Add("Red", 0);
        map.Add("Green", 1);
        map.Add("Blue", 2);

        map.Add("red", 0);
        map.Add("green", 1);
        map.Add("blue", 2);

        GetComponent<Renderer>().material = materials[cur_color];
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= 0.2) flash.enabled = false;
        Debug.Log("y" + " " + Input.acceleration.y);
        Debug.Log("x " + Input.acceleration.x);
    }
    void Update () {        
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        speed = -10 * Mathf.Pow(2, ((score / 50)));
        Vector3 was = GetComponent<Transform>().position;
        ready_to_change = ready_to_change || (Input.acceleration.x > -0.3 && Input.acceleration.x < 0.3);
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || (ready_to_change && Input.acceleration.x <= -0.5))
        {
            ready_to_change = false;
            tile = (int)Mathf.Max(-1, tile - 1);   
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || (ready_to_change && Input.acceleration.x >= 0.5))
        {
            ready_to_change = false;
            tile = (int)Mathf.Min(1, tile + 1);
        }
        was.x = tile;
        gameObject.GetComponent<Transform>().transform.position = was;
        if(increased && score == 0)
        {
            button_listeners.game_over();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        int map_value;
        if (map.TryGetValue(other.gameObject.tag, out map_value))
        {
            if (char.IsUpper(other.gameObject.tag[0]))
            {
                if (map_value == cur_color)
                {
                    GetComponent<AudioSource>().clip = good_pick;
                    score += 10;
                    increased = true;
                }
                else
                {
                    GetComponent<AudioSource>().clip = bad_pick;
                    score /= 2;
                }
                text.text = "Score : " + score;
            }
            else
            {
                flash.enabled = true;
                time = 0;
                GetComponent<AudioSource>().clip = zone_entrance;
                cur_color = map_value;
                GetComponent<Renderer>().material = materials[cur_color];
            }
            if (!button_listeners.mute)
            {
               GetComponent<AudioSource>().Play();
            }
            Destroy(other.gameObject);
        }
          
    }
}
