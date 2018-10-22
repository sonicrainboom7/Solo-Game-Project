using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour {
    GameObject expSpeedUp;
    GameObject expSpeedDown;
    GameObject playerSpeedDown;
    GameObject BombCountUp;
    GameObject BombCountDown;
    GameObject playerSpeedU;
    
	// Use this for initialization
	void Start () {
        expSpeedUp = (Resources.Load("ExpSpeedUp")) as GameObject;
        expSpeedDown = (Resources.Load("ExpSpeedDown")) as GameObject;
        playerSpeedDown = (Resources.Load("SpeedDown")) as GameObject;
        playerSpeedU = (Resources.Load("SpeedU")) as GameObject;
        BombCountUp = (Resources.Load("BombCountUp")) as GameObject;
        BombCountDown = (Resources.Load("BombCountDown")) as GameObject; 

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "BombBlast" )
        {
            Destroy(gameObject);
            int rng = Random.Range(0,7);
           
            
            switch (rng)
            {
                case 0:
                
                    Instantiate(expSpeedUp, transform.position, Quaternion.identity);
                    break;

                case 1:

                    Instantiate(playerSpeedU, transform.position, Quaternion.identity);
                    break;

                case 2:
                    Instantiate(playerSpeedDown, transform.position, Quaternion.identity);
                    break;

                case 3:
                    Instantiate(expSpeedDown, transform.position, Quaternion.identity);
                    break;

                case 4:
                    Instantiate(BombCountUp, transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(BombCountDown, transform.position, Quaternion.identity);
                    break;
                case 6:
                    break;

            }
        }
    }
}
