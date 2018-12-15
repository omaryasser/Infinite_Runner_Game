using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_speed : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, player_controller.speed);
    }
}
