using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public AudioClip deathsound;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "BombBlast")
        {
            AudioSource.PlayClipAtPoint(deathsound, transform.position);
            Destroy(gameObject);

        }
    }
}
