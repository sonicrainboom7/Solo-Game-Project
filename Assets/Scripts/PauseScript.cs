using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {
    public Transform canvas;
    PlayerControl controller;
    GameObject player;
    GameObject gameController;
    AudioSource musicControl;
    public Button Continue;
    public Button Title;
    public Button Leave;



    // Use this for initialization
    void Start () {
        Button resume = Continue.GetComponent<Button>();
        resume.onClick.AddListener(Resume);
        Button title = Title.GetComponent<Button>();
        title.onClick.AddListener(Titlescreen);
        Button exit = Leave.GetComponent<Button>();
        exit.onClick.AddListener(Exit);
        gameController = GameObject.Find("GameController");
        musicControl = gameController.GetComponent<AudioSource>();

        player = (GameObject)(Resources.Load("Player"));
        controller = player.GetComponent<PlayerControl>();
        controller.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                musicControl.Pause();
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                controller.enabled = false;
            }
            else
            {
                musicControl.UnPause();
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                controller.enabled = true;
            }
        }
		
	}
    void Resume()
    {
        musicControl.UnPause();
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        controller.enabled = true;
    }
    void Titlescreen()
    {
        Time.timeScale = 1;
        controller.enabled = true;
        SceneManager.LoadScene("Title");
        
    }
    void Exit()
    {
        Application.Quit();
    }
}
