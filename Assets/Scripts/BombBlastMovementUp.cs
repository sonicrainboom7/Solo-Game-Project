using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlastMovementUp : MonoBehaviour {
    public float speed;
    PlayerControl playerScript;
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerControl>();


    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(playerScript.expSpeed * Time.deltaTime,0 , 0);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Breakable")
        {
            
            Destroy(gameObject);
        }
        
    }
}
