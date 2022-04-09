using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InteractiveFoliage : MonoBehaviour
{
    [SerializeField] private float bendForceOnExit = -0.1f;
    [SerializeField] private bool windIsEnabled;
    [SerializeField] private float baseWindForce = 0f;
    [SerializeField] private float windPeriod = 0f;
    [SerializeField] private float windOffset;
    [SerializeField] private float windForceMultiplier = 0f;
    [SerializeField] private float bendFactor = 0.5f;


    private bool isBending;
    private bool isRebounding;

    private float exitOffset;
    private float enterOffset;


    private float colliderHalfWidth;

    [SerializeField] private Spring spring = new Spring();
    private Mesh meshCache;
    private Transform transformCache;
    private Collider2D colliderCache;

    private void Awake()
    {
        colliderCache = GetComponent<Collider2D>();
        colliderCache.isTrigger = true;
        colliderHalfWidth = colliderCache.bounds.size.x / 2f;

        transformCache = transform;
        meshCache = GetComponent<MeshFilter>().mesh;
    }

    private void OnDestroy()
    {
        Destroy(meshCache);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //CharacterMovement charMovement = col.GetComponent<CharacterMovement>();
        //if (charMovement != null)
        //{
            enterOffset = col.transform.position.x - transformCache.position.x;

            //if (charMovement.Velocity.y < -3f)
            //{
            //    // Apply a force in the proper direction based on which half of the grass we landed on.
            //    if (col.transform.position.x < transformCache.position.x)
            //        spring.ApplyAdditiveForce(-bendForceOnExit);
            //    else
            //        spring.ApplyAdditiveForce(bendForceOnExit);

            //    isRebounding = true;
            //}
        //}
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        //if (col.GetComponent<Player>() != null)
        //{
            float offset = col.transform.position.x - transformCache.position.x;
            if (isBending || Mathf.Sign(enterOffset) != Mathf.Sign(offset))
            {
                isRebounding = false;
                isBending = true;

                // Figure out how far we have moved into the trigger and then map the offset to a [-1, 1] range.
                // 0 would be neutral, -1 to the left and +1 to the right.
                float radius = colliderHalfWidth + colliderCache.bounds.size.x * 0.5f;
                exitOffset = Map(offset, -radius, radius, -1f, 1f);

                // Apply a slow drag back to center
                exitOffset *= 0.9f;

                SetHorizontalOffset(exitOffset);
            }
        //}
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //if (col.GetComponent<Player>() != null)
        //{
            if (isBending)
            {
                // Apply a force in the opposite direction of the way that we're currently bending
                spring.ApplyForceStartingAtPosition(bendForceOnExit * Mathf.Sign(exitOffset), exitOffset);
            }

            isBending = false;
            isRebounding = true;
        //}
    }

    private void FixedUpdate()
    {

        if (windIsEnabled && !isBending)
        {
            var windForce = baseWindForce + Mathf.Pow(Mathf.Sin(Time.time * windPeriod + windOffset) * 0.7f + 0.05f, 4) * 0.05f * windForceMultiplier;
            spring.ApplyAdditiveForce(windForce);

            // Only simulate if we're not rebounding, as that overwritten below.
            if (!isRebounding)
            {
                SetHorizontalOffset(spring.Simulate());
            }
        }
        if (isRebounding)
        {
            SetHorizontalOffset(spring.Simulate());

            // Apply spring forces until its acceleration dies off.
            if (Mathf.Abs(spring.velocity) < 0.000005f)
            {
                // Reset the grass to zero and stop rebounding.
                SetHorizontalOffset(0f);
                isRebounding = false;
            }
        }
    }

    private void SetHorizontalOffset(float offset)
    {
        //MaterialPropertyBlock dest = new MaterialPropertyBlock();
        //GetComponent<SpriteRenderer>().GetPropertyBlock(dest);
        //dest.SetFloat("_FlashAmount", offset);
        //GetComponent<SpriteRenderer>().SetPropertyBlock(dest);

        var verts = meshCache.vertices;
        verts[1].x = 0.5f + offset * bendFactor / transformCache.localScale.x;
        verts[3].x = -0.5f + offset * bendFactor / transformCache.localScale.x;

        meshCache.vertices = verts;
    }

    public static float Map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
