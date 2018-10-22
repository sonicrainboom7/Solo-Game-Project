using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    GameObject controller;
    AudioSource endingMusic;
    AudioSource stageMusic;
    private SpriteRenderer rend;
    public Sprite kiinni;
    public Sprite auki;
    public bool noRequirements;
    public bool needsKey;
    public bool keyCheck = false;
    BoxCollider2D ovi;
    GameObject[] enemycount;
    GameObject[] doppelcount;
    public Transform canvas;
    public Button Title;
    public Button End;



    // Use this for initialization
    void Start()
    {
        Button title = Title.GetComponent<Button>();
        title.onClick.AddListener(Titlescreen);
        Button exit = End.GetComponent<Button>();
        exit.onClick.AddListener(Exit);
        endingMusic = GetComponent<AudioSource>();
        controller = GameObject.Find("GameController");
        stageMusic = controller.GetComponent<AudioSource>();

        


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
    void Update()
    {


        enemycount = GameObject.FindGameObjectsWithTag("Enemy");
        doppelcount = GameObject.FindGameObjectsWithTag("Doppel");
        if (enemycount.Length < 1 && doppelcount.Length < 1 && needsKey == false || noRequirements == true)
        {
            rend.sprite = auki;
            ovi.isTrigger = true;

        }
        if (keyCheck == true)
        {
            rend.sprite = auki;
            ovi.isTrigger = true;

        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            stageMusic.Stop();
            endingMusic.Play();
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);



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

