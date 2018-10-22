using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {
    public Text SpeedValue;
    public Text BlastSpeed;
    public Text BombCount;
    PlayerControl playerScript;
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerControl>();

    }
	
	// Update is called once per frame
	void Update () {

        SpeedValue.text = "= " + playerScript.speed;
        BlastSpeed.text = "= " + playerScript.expSpeed;
        BombCount.text = "= " + playerScript.maxbombcount;

    }
}
