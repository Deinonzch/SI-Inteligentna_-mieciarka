using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;
using System;

public class AstarAI : MonoBehaviour
{
    //The point to move to
    public Vector3 target;

    private Seeker seeker;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 1;

    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    bool gora = false;
    bool prawo = false;
    bool lewo = false;
    bool dol = false;

    float lastx=0;
    float lasty=0;
    //1 gora, 2, prawo, 3, dol, 4 lewo
    int przod = 1;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("cel").transform.position;
        seeker = GetComponent<Seeker>();

        //Start a new path to the targetPosition, return the result to the OnPathComplete function
        seeker.StartPath(transform.position, target, OnPathComplete);
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }

    public void FixedUpdate()
    {
        if (path == null)
        {
            //We have no path to move after yet
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            Debug.Log("End Of Path Reached");
            return;
        }

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        Vector3 roznica = dir;
        dir *= speed * Time.fixedDeltaTime;


        if (Math.Round(lasty, 0) != Math.Round(roznica.y, 0) || Math.Round(lastx, 0) != Math.Round(roznica.x, 0))
        {
            if (Math.Round(roznica.y, 0) == 1)
            {
                gora = true;
            }
            else
            {
                gora = false;
            }
            if (Math.Round(roznica.y, 0) == -1)
            {
                dol = true;
            }
            else
            {
                dol = false;
            }
            if (Math.Round(roznica.x, 0) == 1)
            {
                prawo = true;
            }
            else
            {
                prawo = false;
            }
            if (Math.Round(roznica.x, 0) == -1)
            {
                lewo = true;
            }
            else
            {
                lewo = false;
            }

        }

        lastx = roznica.x;
        lasty = roznica.y;
        //skrecamy w prawo
        if (prawo == true && gora == false && lewo == false && dol == false && przod == 1)
        {
            transform.Rotate(new Vector3(0, 0, -90), Space.World);
            przod = 2;
        }

        if (prawo == true && gora == false && lewo == false && dol == false && przod == 2)
        {
            transform.Rotate(new Vector3(0, 0, 0), Space.World);
        }

        if (prawo == true && gora == false && lewo == false && dol == false && przod == 3)
        {
            transform.Rotate(new Vector3(0, 0, 90), Space.World);
            przod = 2;
        }

        if (prawo == true && gora == false && lewo == false && dol == false && przod == 4)
        {
            transform.Rotate(new Vector3(0, 0, 180), Space.World);
            przod = 2;
        }
        if (prawo == true && gora == false && lewo == false && dol == false && przod == 21)
        {
            transform.Rotate(new Vector3(0, 0, -45), Space.World);
            przod = 2;
        }

        if (prawo == true && gora == false && lewo == false && dol == false && przod == 23)
        {
            transform.Rotate(new Vector3(0, 0, 45), Space.World);
            przod = 2;
        }

        if (prawo == true && gora == false && lewo == false && dol == false && przod == 43)
        {
            transform.Rotate(new Vector3(0, 0, 135), Space.World);
            przod = 2;
        }

        if (prawo == true && gora == false && lewo == false && dol == false && przod == 41)
        {
            transform.Rotate(new Vector3(0, 0, -135), Space.World);
            przod = 2;
        }

        //skret do gory
        if (gora == true && prawo == false && lewo == false && dol == false && przod == 1)
        {
            transform.Rotate(new Vector3(0, 0, 0), Space.World);
        }

        if (gora == true && prawo == false && lewo == false && dol == false && przod == 2)
        {
            transform.Rotate(new Vector3(0, 0, 90), Space.World);
            przod = 1;
        }

        if (gora == true && prawo == false && lewo == false && dol == false && przod == 3)
        {
            transform.Rotate(new Vector3(0, 0, 180), Space.World);
            przod = 1;
        }

        if (gora == true && prawo == false && lewo == false && dol == false && przod == 4)
        {
            transform.Rotate(new Vector3(0, 0, -90), Space.World);
            przod = 1;
        }
        if (gora == true && prawo == false && lewo == false && dol == false && przod == 21)
        {
            transform.Rotate(new Vector3(0, 0, 45), Space.World);
            przod = 1;
        }

        if (gora == true && prawo == false && lewo == false && dol == false && przod == 23)
        {
            transform.Rotate(new Vector3(0, 0, 135), Space.World);
            przod = 1;
        }

        if (gora == true && prawo == false && lewo == false && dol == false && przod == 43)
        {
            transform.Rotate(new Vector3(0, 0, -135), Space.World);
            przod = 1;
        }

        if (gora == true && prawo == false && lewo == false && dol == false && przod == 41)
        {
            transform.Rotate(new Vector3(0, 0, -45), Space.World);
            przod = 1;
        }

        //skret w dol
        if (gora == false && prawo == false && lewo == false && dol == true && przod == 1)
        {
            transform.Rotate(new Vector3(0, 0, 180), Space.World);
            przod = 3;
        }

        if (gora == false && prawo == false && lewo == false && dol == true && przod == 2)
        {
            transform.Rotate(new Vector3(0, 0, -90), Space.World);
            przod = 3;
        }

        if (gora == false && prawo == false && lewo == false && dol == true && przod == 3)
        {
            transform.Rotate(new Vector3(0, 0, 0), Space.World);
        }

        if (gora == false && prawo == false && lewo == false && dol == true && przod == 4)
        {
            transform.Rotate(new Vector3(0, 0, 90), Space.World);
            przod = 3;
        }
        if (gora == false && prawo == false && lewo == false && dol == true && przod == 21)
        {
            transform.Rotate(new Vector3(0, 0, -135), Space.World);
            przod = 3;
        }

        if (gora == false && prawo == false && lewo == false && dol == true && przod == 23)
        {
            transform.Rotate(new Vector3(0, 0, -45), Space.World);
            przod = 3;
        }

        if (gora == false && prawo == false && lewo == false && dol == true && przod == 43)
        {
            transform.Rotate(new Vector3(0, 0, 45), Space.World);
            przod = 3;
        }

        if (gora == false && prawo == false && lewo == false && dol == true && przod == 41)
        {
            transform.Rotate(new Vector3(0, 0, 135), Space.World);
            przod = 3;
        }

        //skret w lewo
        if (gora == false && prawo == false && lewo == true && dol == false && przod == 1)
        {
            transform.Rotate(new Vector3(0, 0, 90), Space.World);
            przod = 4;
        }

        if (gora == false && prawo == false && lewo == true && dol == false && przod == 2)
        {
            transform.Rotate(new Vector3(0, 0, 180), Space.World);
            przod = 4;
        }

        if (gora == false && prawo == false && lewo == true && dol == false && przod == 3)
        {
            transform.Rotate(new Vector3(0, 0, -90), Space.World);
            przod = 4;
        }

        if (gora == false && prawo == false && lewo == true && dol == false && przod == 4)
        {
            transform.Rotate(new Vector3(0, 0, 0), Space.World);
        }
        if (gora == false && prawo == false && lewo == true && dol == false && przod == 21)
        {
            transform.Rotate(new Vector3(0, 0, 135), Space.World);
            przod = 4;
        }

        if (gora == false && prawo == false && lewo == true && dol == false && przod == 23)
        {
            transform.Rotate(new Vector3(0, 0, -135), Space.World);
            przod = 4;
        }

        if (gora == false && prawo == false && lewo == true && dol == false && przod == 43)
        {
            transform.Rotate(new Vector3(0, 0, -45), Space.World);
            przod = 4;
        }

        if (gora == false && prawo == false && lewo == true && dol == false && przod == 41)
        {
            transform.Rotate(new Vector3(0, 0, 45), Space.World);
            przod = 4;
        }

        //skrecamy w prawo góra
        if (prawo == true && gora == true && lewo == false && dol == false && przod == 1)
        {
            transform.Rotate(new Vector3(0, 0, -45), Space.World);
            przod = 21;
        }

        if (prawo == true && gora == true && lewo == false && dol == false && przod == 2)
        {
            transform.Rotate(new Vector3(0, 0, 45), Space.World);
            przod = 21;
        }

        if (prawo == true && gora == true && lewo == false && dol == false && przod == 3)
        {
            transform.Rotate(new Vector3(0, 0, 135), Space.World);
            przod = 21;
        }

        if (prawo == true && gora == true && lewo == false && dol == false && przod == 4)
        {
            transform.Rotate(new Vector3(0, 0, -135), Space.World);
            przod = 21;
        }
        if (prawo == true && gora == true && lewo == false && dol == false && przod == 21)
        {
            transform.Rotate(new Vector3(0, 0, 0), Space.World);
        }

        if (prawo == true && gora == true && lewo == false && dol == false && przod == 23)
        {
            transform.Rotate(new Vector3(0, 0, 90), Space.World);
            przod = 21;
        }

        if (prawo == true && gora == true && lewo == false && dol == false && przod == 43)
        {
            transform.Rotate(new Vector3(0, 0, 180), Space.World);
            przod = 21;
        }

        if (prawo == true && gora == true && lewo == false && dol == false && przod == 41)
        {
            transform.Rotate(new Vector3(0, 0, -90), Space.World);
            przod = 21;
        }

        //skret do prawy dol
        if (gora == false && prawo == true && lewo == false && dol == true && przod == 1)
        {
            transform.Rotate(new Vector3(0, 0, -135), Space.World);
            przod = 23;
        }

        if (gora == false && prawo == true && lewo == false && dol == true && przod == 2)
        {
            transform.Rotate(new Vector3(0, 0, -45), Space.World);
            przod = 23;
        }

        if (gora == false && prawo == true && lewo == false && dol == true && przod == 3)
        {
            transform.Rotate(new Vector3(0, 0, 45), Space.World);
            przod = 23;
        }

        if (gora == false && prawo == true && lewo == false && dol == true && przod == 4)
        {
            transform.Rotate(new Vector3(0, 0, 135), Space.World);
            przod = 23;
        }
        if (gora == false && prawo == true && lewo == false && dol == true && przod == 21)
        {
            transform.Rotate(new Vector3(0, 0, -90), Space.World);
        }

        if (gora == false && prawo == true && lewo == false && dol == true && przod == 23)
        {
            transform.Rotate(new Vector3(0, 0, 0), Space.World);
        }

        if (gora == false && prawo == true && lewo == false && dol == true && przod == 43)
        {
            transform.Rotate(new Vector3(0, 0, 90), Space.World);
            przod = 23;
        }

        if (gora == false && prawo == true && lewo == false && dol == true && przod == 41)
        {
            transform.Rotate(new Vector3(0, 0, 180), Space.World);
            przod = 23;
        }

        //skret w lewy dol
        if (gora == false && prawo == false && lewo == true && dol == true && przod == 1)
        {
            transform.Rotate(new Vector3(0, 0, 135), Space.World);
            przod = 43;
        }

        if (gora == false && prawo == false && lewo == true && dol == true && przod == 2)
        {
            transform.Rotate(new Vector3(0, 0, -135), Space.World);
            przod = 43;
        }

        if (gora == false && prawo == false && lewo == true && dol == true && przod == 3)
        {
            transform.Rotate(new Vector3(0, 0, -45), Space.World);
            przod = 43;
        }

        if (gora == false && prawo == false && lewo == true && dol == true && przod == 4)
        {
            transform.Rotate(new Vector3(0, 0, 45), Space.World);
            przod = 43;
        }
        if (gora == false && prawo == false && lewo == true && dol == true && przod == 21)
        {
            transform.Rotate(new Vector3(0, 0, 180), Space.World);
            przod = 43;
        }

        if (gora == false && prawo == false && lewo == true && dol == true && przod == 23)
        {
            transform.Rotate(new Vector3(0, 0, -90), Space.World);
            przod = 43;
        }

        if (gora == false && prawo == false && lewo == true && dol == true && przod == 43)
        {
            transform.Rotate(new Vector3(0, 0, 0), Space.World);
        }

        if (gora == false && prawo == false && lewo == true && dol == true && przod == 41)
        {
            transform.Rotate(new Vector3(0, 0, 90), Space.World);
            przod = 43;
        }

        //skret w lewo gora
        if (gora == true && prawo == false && lewo == true && dol == false && przod == 1)
        {
            transform.Rotate(new Vector3(0, 0, 45), Space.World);
            przod = 41;
        }

        if (gora == true && prawo == false && lewo == true && dol == false && przod == 2)
        {
            transform.Rotate(new Vector3(0, 0, 135), Space.World);
            przod = 41;
        }

        if (gora == true && prawo == false && lewo == true && dol == false && przod == 3)
        {
            transform.Rotate(new Vector3(0, 0, -135), Space.World);
            przod = 41;
        }

        if (gora == true && prawo == false && lewo == true && dol == false && przod == 4)
        {
            transform.Rotate(new Vector3(0, 0, -45), Space.World);
            przod = 41;
        }
        if (gora == true && prawo == false && lewo == true && dol == false && przod == 21)
        {
            transform.Rotate(new Vector3(0, 0, 90), Space.World);
            przod = 41;
        }

        if (gora == true && prawo == false && lewo == true && dol == false && przod == 23)
        {
            transform.Rotate(new Vector3(0, 0, 180), Space.World);
            przod = 41;
        }

        if (gora == true && prawo == false && lewo == true && dol == false && przod == 43)
        {
            transform.Rotate(new Vector3(0, 0, -90), Space.World);
            przod = 41;
        }

        if (gora == true && prawo == false && lewo == true && dol == false && przod == 41)
        {
            transform.Rotate(new Vector3(0, 0, 0), Space.World);
        }

        prawo = false;
        gora = false;
        dol = false;
        lewo = false;
        //transform.Rotate(Vector3.back * Time.deltaTime * 20, Space.World);
        print("start:" + Math.Round(roznica.x,0) + " " + Math.Round(roznica.y,0) + " " + roznica.x + " " + roznica.y);
        transform.Translate(dir, Space.World);

        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("cel"))
        {
            print(coll.name.StartsWith("cel"));
            // Get longer in next Move call

            // Remove the Food
            Destroy(coll.gameObject);
        }
    }
}