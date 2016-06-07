﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using System;

public class MultipleAstarAI : MonoBehaviour
{
    public GameObject[] targets;
    public Vector3[] vectorTargets;
    private Seeker seeker;
    private bool pathComplete;
    //The calculated path
    public Path path;
    // Use this for initialization
    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;
    //The AI's speed per second
    public float speed = 1;

    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    bool gora = false;
    bool prawo = false;
    bool lewo = false;
    bool dol = false;

    float lastx = 0;
    float lasty = 0;
    //1 gora, 2, prawo, 3, dol, 4 lewo
    int przod = 1;
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Smietniki");
        int ilosc = targets.Length;
        vectorTargets = new Vector3[ilosc+1];
        seeker = GetComponent<Seeker>();
        int i = 1;
        vectorTargets[0] = seeker.transform.position;
        foreach (var e in targets)
        {
            vectorTargets[i] = e.transform.position;
            i++;
        }     
            //Start a new path to the targetPosition, return the result to the OnPathComplete function
        seeker.StartPath(vectorTargets[0], vectorTargets[1], OnPathComplete);
        

    }

    void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
            pathComplete = true;
        }
    }

    public void FixedUpdate()
    {
        if (path == null)
        {
            //We have no path to move after yet
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count && pathComplete == true)
        {
            Debug.Log("End Of Path Reached");
            Start();
            pathComplete = false;
            return;
        }

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        Vector3 roznica = dir;
        dir *= speed * Time.fixedDeltaTime;

        if (Math.Round(lastx, 0) != Math.Round(roznica.x, 0))
        {
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


        if (Math.Round(lasty, 0) != Math.Round(roznica.y, 0))
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
        }

        lastx = roznica.x;
        lasty = roznica.y;

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

        prawo = false;
        gora = false;
        dol = false;
        lewo = false;

 
        transform.Translate(dir, Space.World);
        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
    public void OnDisable()
    {
        seeker.pathCallback -= OnPathComplete;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("SmietnikAluminium") || coll.name.StartsWith("SmietnikPapier") || coll.name.StartsWith("SmietnikPlastik"))
        {
            // Get longer in next Move call

            // Remove the Food
            Destroy(coll.gameObject);
        }
    }
}
