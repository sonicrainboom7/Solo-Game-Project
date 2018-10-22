using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    AudioSource stageMusic;
    public Transform canvas;
    

    // Use this for initialization
    void Start () {
        stageMusic = GetComponent<AudioSource>();
        
        



    }
	
	// Update is called once per frame
	void Update () {
		
	}
     public void GameOver()
    {

        stageMusic.Stop();
        canvas.gameObject.SetActive(true);
        
    }
}
