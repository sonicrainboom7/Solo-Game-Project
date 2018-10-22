using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Doppelgangler : MonoBehaviour
{
    GameObject bomb;
    public Sprite etu;
    public Sprite taka;
    public Sprite sivu;
    private SpriteRenderer rendaus;
    public float speed;
    public float expSpeed;
    public bool noBombs;
    bool bombtimer = false;
    float timer = 2.0f;
    public int bombcount = 0;
    public int maxbombcount = 1;
    public int minbombcount = 1;







    // Use this for initialization
    void Start()
    {
       
        bomb = (GameObject)(Resources.Load("Bomb"));
        rendaus = GetComponent<SpriteRenderer>();
        if (rendaus.sprite == null)
        {
            rendaus.sprite = etu;
        }




    }



    // Update is called once per frame
    void Update()
    {

        transform.Translate((Input.GetAxis("Horizontal") * Time.deltaTime * speed) * -1, (Input.GetAxis("Vertical") * Time.deltaTime * speed) * -1, 0f);
        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            rendaus.sprite = etu;
        }
        if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            rendaus.sprite = taka;
        }
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            rendaus.sprite = sivu;
            rendaus.flipX = true;
        }
        if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            rendaus.sprite = sivu;
            rendaus.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && bombcount < maxbombcount && noBombs == false && bombtimer == false)
        {
            bombcount++;
            Instantiate(bomb, transform.position, Quaternion.identity);
            bombtimer = true;
        }
        if (bombtimer == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                bombcount--;
                timer = 2.0f;
                bombtimer = false;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "BombBlast" || col.gameObject.tag == "Enemy")
        {


            Destroy(gameObject);


            



        }
    }


}