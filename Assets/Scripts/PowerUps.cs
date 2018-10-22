using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    GameObject player;
    PlayerControl playerScript;
    AudioClip powerUp;
   
    
    

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");


        playerScript = player.GetComponent<PlayerControl>();
        powerUp = (AudioClip)(Resources.Load("PowerUp"));



    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player") { 
        AudioSource.PlayClipAtPoint(powerUp, transform.position);
    }
        if (gameObject.tag == "speedUp" && col.gameObject.tag == "player")
        {

            playerScript.speed += 2;
            Destroy(gameObject);
        } else if (col.gameObject.tag == "BombBlast")
        {
            Destroy(gameObject);
        }

        if (gameObject.tag == "expSpeed" && col.gameObject.tag == "player")
        {
            playerScript.expSpeed += 1f;
            Destroy(gameObject);
        } else if (col.gameObject.tag == "BombBlast")
        {
            Destroy(gameObject);
        }



        
        if (gameObject.tag == "ExpSpeedDown" && col.gameObject.tag == "player")
        {
            playerScript.expSpeed -= 1f;
            Destroy(gameObject);
        } else if (col.gameObject.tag == "BombBlast")
        {
            Destroy(gameObject);
        }




        if (gameObject.tag == "speedDown" && col.gameObject.tag == "player")
        {

            playerScript.speed -= 2;
            Destroy(gameObject);
        } else if (col.gameObject.tag == "BombBlast")
        {
            Destroy(gameObject);
        }

        if (gameObject.tag == "BombCountDown" && col.gameObject.tag == "player")
        {

            playerScript.maxbombcount -= 1;
            Destroy(gameObject);
        } else if (col.gameObject.tag == "BombBlast")
        {
            Destroy(gameObject);
        }

        if (gameObject.tag == "BombCountUp" && col.gameObject.tag == "player")
        {

            playerScript.maxbombcount += 1;
            Destroy(gameObject);
        } else if (col.gameObject.tag == "BombBlast")
        {
            Destroy(gameObject);
        }
        
    }
}

