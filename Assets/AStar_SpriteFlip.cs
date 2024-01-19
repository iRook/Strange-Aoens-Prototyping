using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AStar_SpriteFlip : MonoBehaviour
{

    public AIPath aiPath;
    public Animator animator;


    float animationSpeed = 1f;
    float xDisplacementRatio = 1f;
    float yDisplacementRatio = 1f;

    // Update is called once per frame

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        xDisplacementRatio = Mathf.Abs(aiPath.desiredVelocity.x / aiPath.maxSpeed);
        yDisplacementRatio = Mathf.Abs(aiPath.desiredVelocity.y / aiPath.maxSpeed);
        animator.speed = Mathf.Max(xDisplacementRatio, yDisplacementRatio);

        if (aiPath.desiredVelocity.x >= 0.01)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

}
