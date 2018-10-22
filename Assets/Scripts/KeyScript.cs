using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    GameEnd door;
    GameObject ovi;
    
    
    // Use this for initialization
    void Start()
    {
        ovi = GameObject.Find("Door");
        door = ovi.GetComponent<GameEnd>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
           
            door.keyCheck = true;
            Destroy(gameObject);
        }
    }
}
