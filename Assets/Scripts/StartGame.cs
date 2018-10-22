using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StartGame : MonoBehaviour {
    public Transform controlCanvas;
    public Button GameStart;
    public Button Controls;
    public Button Back;
    public Button End;

    // Use this for initialization
    void Start()
    {
        Button start = GameStart.GetComponent<Button>();
        start.onClick.AddListener(GameBegin);
        Button gamecontrols = Controls.GetComponent<Button>();
        gamecontrols.onClick.AddListener(ControlPage);
        Button quit = End.GetComponent<Button>();
        quit.onClick.AddListener(Stop);
        Button back = Back.GetComponent<Button>();
        back.onClick.AddListener(GoBack);

    }
        // Update is called once per frame
        void Update () {
            
        }
    void GameBegin()
    {
        SceneManager.LoadScene("Stage1");
    }
    void ControlPage()
    {
        controlCanvas.gameObject.SetActive(true);
    }
    void GoBack()
    {
        controlCanvas.gameObject.SetActive(false);
    }

    void Stop()
    {
        Application.Quit();
    }
 }

