using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour {
    
    GameObject bomb;
    BombScript bombScript;
    GameObject controller;
    GameController control;
    public Sprite etu;
    public Sprite taka;
    public Sprite sivu;
    private SpriteRenderer rendaus;
    public float speed;
    public float expSpeed;
    public bool noBombs;
    float maxspeed = 10;
    float minspeed = 2;
    float maxexpSpeed = 5;
    float minexpSpeed = 1;
    public int bombcount = 0;
    public int maxbombcount = 1;
    public int minbombcount = 1;
    
    
    





    // Use this for initialization
    void Start () {
        controller = GameObject.Find("GameController");
        bomb = (GameObject)(Resources.Load("Bomb"));
        control = controller.GetComponent<GameController>();
        bombScript = bomb.GetComponent<BombScript>();
       





        rendaus = GetComponent<SpriteRenderer>();
        if (rendaus.sprite == null)
        {
            rendaus.sprite = etu;
        }
         



    }

    
   
    // Update is called once per frame
    void Update()
    {
       
        
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0f);
            if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                rendaus.sprite = taka;
            }
            if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                rendaus.sprite = etu;
            }
            if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
            {
                rendaus.sprite = sivu;
                rendaus.flipX = false;
            }
            if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                rendaus.sprite = sivu;
                rendaus.flipX = true;
            }
        if (Input.GetKeyDown(KeyCode.E) && bombcount < maxbombcount && noBombs == false)
        {
            bombcount++;
            Instantiate(bomb, transform.position, Quaternion.identity);
                
            }


        
            if (speed > maxspeed)
            {
                speed = maxspeed;
            }
            if (expSpeed > maxexpSpeed)
            {
                expSpeed = maxexpSpeed;
            }
            if (expSpeed < minexpSpeed)
            {
                expSpeed = minexpSpeed;
            }
            if (speed < minspeed)
            {
                speed = minspeed;
            }
            if (maxbombcount < minbombcount)
            {
                maxbombcount = minbombcount;
            }


        }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "BombBlast" || col.gameObject.tag == "Enemy")
        {
            

            Destroy(gameObject);
           

            

            control.GameOver();
            


        }
    }
    

}
