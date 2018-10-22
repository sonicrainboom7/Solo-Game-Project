using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoppelBomb : MonoBehaviour
{
    AudioClip xplosion;
    GameObject bombBlastUp;
    GameObject bombBlastDown;
    GameObject bombBlastLeft;
    GameObject bombBlastRight;
    public GameObject InstbombBlast;
    public GameObject InstbombBlast2;
    public GameObject InstbombBlast3;
    public GameObject InstbombBlast4;
    Doppelgangler doppelScript;


    GameObject doppel;







    float timer = 2;



    // Use this for initialization
    void Start()
    {
        bombBlastUp = (GameObject)(Resources.Load("BombBlastUp"));
        bombBlastDown = (GameObject)(Resources.Load("BombBlastDown"));
        bombBlastLeft = (GameObject)(Resources.Load("BombBlastLeft"));
        bombBlastRight = (GameObject)(Resources.Load("BombBlastRight"));
        xplosion = (AudioClip)(Resources.Load("Bomb+1"));
        doppel = (GameObject)(Resources.Load("DoppelGanger"));
        doppelScript = doppel.GetComponent<Doppelgangler>();


    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            AudioSource.PlayClipAtPoint(xplosion, transform.position);
            Destroy(gameObject);
            InstbombBlast = Instantiate(bombBlastRight, transform.position + (transform.right * 0.5f), transform.rotation);
            InstbombBlast.transform.localScale = new Vector3(0.2f, 0.2f, 1);
            InstbombBlast2 = Instantiate(bombBlastUp, transform.position + (transform.up * 0.5f), Quaternion.Euler(0, 0, 90));
            InstbombBlast2.transform.localScale = new Vector3(0.2f, 0.2f, 1);
            InstbombBlast3 = Instantiate(bombBlastLeft, transform.position + (-transform.right * 0.5f), transform.rotation);
            InstbombBlast3.transform.localScale = new Vector3(0.2f, 0.2f, 1);
            InstbombBlast4 = Instantiate(bombBlastDown, transform.position + (-transform.up * 0.5f), Quaternion.Euler(0, 0, 90));
            InstbombBlast4.transform.localScale = new Vector3(0.2f, 0.2f, 1);
            Destroy(InstbombBlast, 1);
            Destroy(InstbombBlast2, 1);
            Destroy(InstbombBlast3, 1);
            Destroy(InstbombBlast4, 1);
            doppelScript.bombcount--;





        }



    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "BombBlast")
        {
            timer = 0;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        this.GetComponent<Collider2D>().isTrigger = false;
    }

}