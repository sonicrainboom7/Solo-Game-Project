using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour {

    GameObject player;
    public Vector3 offset;

    // Use this for initialization
    void Start () {
        
        
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        else
        {
            transform.position = player.transform.position + offset;
        }



    }
}
