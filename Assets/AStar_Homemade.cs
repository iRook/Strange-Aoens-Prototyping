using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AStar_Homemade : MonoBehaviour
{

    public Transform target;
    public Transform sprite;

    [SerializeField] private float speed = 200f;
    [SerializeField] private float nextWaypointDistance = 2f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        // repeats a method (for us, UpdatePath) every X seconds (0.5f for us)
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        // if not currently calculationg a path
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        // if we didnt get any errors
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Flip()
    {
        if (rb.velocity.x >= 0.01)
        {
            sprite.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            sprite.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if no path, return out of function
        if (path == null)
        {
            return;
        }

        // if current waypoint at the end of a path
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        // Added (Vector2) to cast as a vector2 becuase rb.position is a Vector2
        // normalized so that length of vector is 1
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        Flip();
    }
}
