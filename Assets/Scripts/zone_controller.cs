using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone_controller : MonoBehaviour
{
    public GameObject[] zones;
    float diff = 0;
    void Start()
    {
        Random.InitState(40);
    }

    void FixedUpdate()
    {
        diff += Time.deltaTime;
        if (diff >= 3)
        {
            diff = 0;
            collider_controller.colliders_inbetween = 0;
            int zone = Random.Range(0, 2 + 1);
            while(zone == player_controller.cur_color) zone = Random.Range(0, 2 + 1);
            GameObject cur = Instantiate(zones[zone], new Vector3(-0.6f, 0, 120), Quaternion.Euler(new Vector3(-90, 0, 0)));
            cur.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, player_controller.speed);
        }
    }
}
