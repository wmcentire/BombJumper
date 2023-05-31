using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawHazard : Hazard
{
    [SerializeField] Waypoint waypoint;
    [SerializeField] float speed = 1.0f;
    private bool forwards = true;

    Rigidbody2D rb;
    void Start()
    {
        this.TryGetComponent<Rigidbody2D>(out rb);
    }

    void Update()
    {
        if(rb != null)
        {
            Vector2 position = this.transform.position;
            Vector2 distance = position - (Vector2)waypoint.transform.position; // or flip this if it's wrong

            Vector2 direction = distance.normalized;
            rb.position += (direction * speed); // vector calculations dude

            //next waypoint
            if (distance.magnitude < 2.0f)
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
