using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_controller : MonoBehaviour {
    public GameObject[] colliders;
    float time = 0;
    static public int colliders_inbetween = 0;
	void Start () {
        Random.InitState(40);
	}
	
	void FixedUpdate () {
        time += Time.deltaTime;
        if(time >= Mathf.Max(0.2f, 0.5f - 0.2f * (player_controller.speed / 50)))
        {
            int put_collider = Random.Range(0, 1 + 1);
            int first_position = -3;
            if(put_collider == 1)
            {
                int collider = Random.Range(0, 2 + 1);
                int position = first_position = Random.Range(-1, 1 + 1);
                Instantiate(colliders[collider], new Vector3(position, 1, 90), Quaternion.identity);
                colliders_inbetween++;
            }
            put_collider = Random.Range(0, 1 + 1);
            if (put_collider == 1)
            {
                int collider = Random.Range(0, 2 + 1);
                int position = Random.Range(-1, 1 + 1);
                while(position == first_position)position = Random.Range(-1, 1 + 1);
                Instantiate(colliders[collider], new Vector3(position, 1, 90), Quaternion.identity);
                colliders_inbetween++;
            }
            time = 0;
        }
	}
}
