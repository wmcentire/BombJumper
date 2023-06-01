using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawHazard : Hazard
{
    [SerializeField] Waypoint waypoint;
    [SerializeField] float speed = 1.0f;
    private bool forwards = true;

    void Start()
    {

    }

    void Update()
    {
        {
            Vector2 position = this.transform.position;
            Vector2 distance =  (Vector2)waypoint.transform.position - position; // or flip this if it's wrong

            Vector2 direction = distance.normalized;
            this.transform.Translate(direction * speed * Time.deltaTime); // vector calculations dude

            //next waypoint
            if (distance.magnitude < 0.5f)
            {
                if (forwards)
                {
                    if (waypoint.nextWaypoint == null)
                    {
                        forwards = false;
                    }
                    waypoint = waypoint.nextWaypoint;
                }
                else
                {
                    if (waypoint.prevWaypoint == null)
                    {
                        forwards = true;
                    }
                    waypoint = waypoint.prevWaypoint;
                }
            }
        }
        
        
    }
}
