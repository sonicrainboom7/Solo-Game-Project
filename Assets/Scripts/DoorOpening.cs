using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorOpening : MonoBehaviour {
    private SpriteRenderer rend;
    public Sprite kiinni;
    public Sprite auki;
    public bool noRequirements;
    public bool needsKey;
    public bool keyCheck = false;
    BoxCollider2D ovi;
    GameObject[] enemycount;
    GameObject[] doppelcount;
    
    int currentLevel;

    

	// Use this for initialization
	void Start () {
        


        keyCheck = false;

        
        ovi = GetComponent<BoxCollider2D>();
        ovi.isTrigger = false;
        rend = GetComponent<SpriteRenderer>();
        if (rend.sprite == null)
        {
            rend.sprite = kiinni;
        }
    }
	
	// Update is called once per frame
	void Update () {
        

        enemycount = GameObject.FindGameObjectsWithTag("Enemy");
        doppelcount = GameObject.FindGameObjectsWithTag("Doppel");
        if (enemycount.Length < 1 && doppelcount.Length < 1 && needsKey == false || noRequirements == true)
        {
            rend.sprite = auki;
            ovi.isTrigger = true;
            
        }
        else if (keyCheck == true)
        {
            rend.sprite = auki;
            ovi.isTrigger = true;

        }
         

    }
    void OnTriggerEnter2D(Collider2D col)
    {
      if (col.gameObject.tag == "player")
        {
            
         
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
            
            
            
        
    }
    void Titlescreen()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Title");

    }
    void Exit()
    {
        Application.Quit();
    }

}
