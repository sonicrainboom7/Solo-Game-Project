using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public Waypoint[] wayPoints;
    public float speed = 3f;
    public bool isCircular;
    // Always true at the beginning because the moving object will always move towards the first waypoint
    public bool inReverse = true;
    public SpriteRenderer rend;
    public Sprite etu;
    public Sprite taka;
    public Sprite sivu;
    private Waypoint currentWaypoint;
    private int previousIndex;
    private int currentIndex = 0;
    private bool isWaiting = false;
    private float speedStorage = 0;



    /**
     * Initialisation
     * 
     */
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if (wayPoints.Length > 0)
        {
            currentWaypoint = wayPoints[0];
        }
    }



    /**
     * Update is called once per frame
     * 
     */
    void Update()
    {
       
        if (currentWaypoint != null && !isWaiting)
        {
            MoveTowardsWaypoint();
        }
    }



    /**
     * Pause the mover
     * 
     */
    void Pause()
    {
        isWaiting = !isWaiting;
    }



    /**
     * Move the object towards the selected waypoint
     * 
     */
    private void MoveTowardsWaypoint()
    {
        // Get the moving objects current position
        Vector3 currentPosition = this.transform.position;
        

        // Get the target waypoints position
        Vector3 targetPosition = currentWaypoint.transform.position;

        if(currentPosition.x > targetPosition.x + 0.5f)
        {
            rend.sprite = sivu;
            rend.flipX = false;
            
        }
        if (currentPosition.x < targetPosition.x - 0.5f)
        {
            rend.sprite = sivu;
            rend.flipX = true;
            
        }
        if(currentPosition.y > targetPosition.y + 0.5f)
        {
            rend.sprite = etu;
            
        }
        if (currentPosition.y < targetPosition.y - 0.5f)
        {
            rend.sprite = taka;
            
        }

        // If the moving object isn't that close to the waypoint
        if (Vector3.Distance(currentPosition, targetPosition) > .1f)
        {

            // Get the direction and normalize
            Vector3 directionOfTravel = targetPosition - currentPosition;
            directionOfTravel.Normalize();

            //scale the movement on each axis by the directionOfTravel vector components
            this.transform.Translate(
                directionOfTravel.x * speed * Time.deltaTime,
                directionOfTravel.y * speed * Time.deltaTime,
                directionOfTravel.z * speed * Time.deltaTime,
                Space.World
            );
        }
        else
        {

            // If the waypoint has a pause amount then wait a bit
            if (currentWaypoint.waitSeconds > 0)
            {
                Pause();
                Invoke("Pause", currentWaypoint.waitSeconds);
            }

            // If the current waypoint has a speed change then change to it
            if (currentWaypoint.speedOut > 0)
            {
                speedStorage = speed;
                speed = currentWaypoint.speedOut;
            }
            else if (speedStorage != 0)
            {
                speed = speedStorage;
                speedStorage = 0;
            }

            NextWaypoint();
        }
    }



    /**
     * Work out what the next waypoint is going to be
     * 
     */
    private void NextWaypoint()
    {
        if (isCircular)
        {

            if (!inReverse)
            {
                previousIndex = currentIndex;
                currentIndex = (currentIndex + 1 >= wayPoints.Length) ? 0 : currentIndex + 1;
            }
            else
            {
                previousIndex = currentIndex;
                currentIndex = (currentIndex == 0) ? wayPoints.Length - 1 : currentIndex - 1;
            }

        }
        else
        {

            // If at the start or the end then reverse
            if ((!inReverse && currentIndex + 1 >= wayPoints.Length) || (inReverse && currentIndex == 0))
            {
                inReverse = !inReverse;
            }
            currentIndex = (!inReverse) ? currentIndex + 1 : currentIndex - 1;

        }

        currentWaypoint = wayPoints[currentIndex];
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "Breakable" && inReverse == false && isCircular == false || collision.gameObject.tag == "Bomb" && inReverse == false && isCircular == false || collision.gameObject.tag == "Enemy" && inReverse == false && isCircular == false)
        {
            inReverse = true;
            currentIndex = currentIndex - 1;
            currentWaypoint = wayPoints[currentIndex];
        } else if(collision.gameObject.tag == "Breakable" && inReverse == true && isCircular == false || collision.gameObject.tag == "Bomb" && inReverse == true && isCircular == false || collision.gameObject.tag == "Enemy" && inReverse == true && isCircular == false)
        {
            inReverse = false;
            currentIndex = currentIndex + 1;
            currentWaypoint = wayPoints[currentIndex];
        }
        if (collision.gameObject.tag == "Breakable" && inReverse == false && isCircular == true || collision.gameObject.tag == "Bomb" && inReverse == false && isCircular == true || collision.gameObject.tag == "Enemy" && inReverse == false && isCircular == true)
        {
            inReverse = true;
            //currentIndex = currentIndex - 1;
            currentWaypoint = wayPoints[previousIndex];
        }
        else if (collision.gameObject.tag == "Breakable" && inReverse == true && isCircular == true || collision.gameObject.tag == "Bomb" && inReverse == true && isCircular == true || collision.gameObject.tag == "Enemy" && inReverse == true && isCircular == true)
        {
            inReverse = false;
            //currentIndex = currentIndex + 1;
            currentWaypoint = wayPoints[previousIndex];
        }

    }
}