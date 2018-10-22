using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
   
    public Sprite eyesOpen;
    public Sprite eyesClosed;
    public Image gameOverImage;
    public Button Re;
    public Button Title;
    public Button Leave;
    public bool animationchange = false;
    float delay = 0.5f;
    

    // Use this for initialization
    void Start () {
        Button resume = Re.GetComponent<Button>();
        resume.onClick.AddListener(DoOver);
        Button title = Title.GetComponent<Button>();
        title.onClick.AddListener(Titlescreen);
        Button exit = Leave.GetComponent<Button>();
        exit.onClick.AddListener(Exit);
        
    }
	
	// Update is called once per frame
	void Update () {
        
        delay -= Time.deltaTime;
        
        if (delay <= 0 && animationchange == false)
        {
            gameOverImage.sprite = eyesClosed;
            delay = 0.5f;
            animationchange = true;
        }
        if (delay <= 0 && animationchange == true)
        {
            gameOverImage.sprite = eyesOpen;
            delay = 0.5f;
            animationchange = false;
        }

    }
   
    void DoOver()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



    }
    void Titlescreen()
    {
        

        SceneManager.LoadScene("Title");


    }
    void Exit()
    {
        Application.Quit();
    }
}
