using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer_controller : MonoBehaviour {

    public GameObject last_tile;
    public float speed;
	// Use this for initialization
	void Start () {
        speed = -5;
	}
	

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Vector3 pos = new Vector3(0, 0, last_tile.GetComponent<Transform>().position.z + 60);
            last_tile = Instantiate(last_tile, pos, Quaternion.identity);
            last_tile.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
            last_tile.name = "Last Tile";
        }
        Destroy(other.gameObject);
    }
}
