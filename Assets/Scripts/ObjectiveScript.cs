using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveScript : MonoBehaviour {
    PlayerControl controller;
    GameObject player;
    public Transform canvas;
    public Button begin;
    // Use this for initialization
    void Start() {
        Button start = begin.GetComponent<Button>();
        start.onClick.AddListener(Begin);
        player = (GameObject)(Resources.Load("Player") as GameObject);
        controller = player.GetComponent<PlayerControl>();
        controller.enabled = false;
        Time.timeScale = 0;

    }

    // Update is called once per frame
    
    void Begin() {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        controller.enabled = true;


    }
}
