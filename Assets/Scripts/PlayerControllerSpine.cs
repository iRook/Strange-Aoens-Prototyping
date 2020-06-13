using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class PlayerControllerSpine : MonoBehaviour
{

    //public SkeletonAnimation skeletonAnimation;
    //public AnimationReferenceAsset idle, run, jump;
    //public string currentState;
    //public float speed;
    //public float movement;
    //private Rigidbody2D rb;
    //public string currentAnimation;
    //public float jumpSpeed;
    //public string previousState;

    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        currentState = "Idle";
//        SetCharacterState(currentState);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Move();
//    }

//    //sets character animation
//    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
//    {
//        if (animation.name.Equals(currentAnimation))
//        {
//            return;
//        }
//        Spine.TrackEntry animationEntry = skeletonAnimation.state.SetAnimation(0, animation, loop);
//        animationEntry.TimeScale = timeScale;
//        animationEntry.Complete += AnimationEntry_Complete;
//        currentAnimation = animation.name;
//    }

//    //Do something after animation completes
//    private void AnimationEntry_Complete(Spine.TrackEntry trackEntry)
//    {
//        //throw new System.NotImplementedException();
//        if (currentState.Equals("Jump"))
//        {
//            SetCharacterState(previousState);
//        }
//    }

//    //checks character state and stes the animation accordingly
//    public void SetCharacterState(string state)
//    {
//        if (state.Equals("Run"))
//        {
//            SetAnimation(run, true, 1f);
//        }
//        else if (state.Equals("Jump"))
//        {
//            SetAnimation(jump, false, 1f);
//        }

//        else //if (state.Equals("Idle"))
//        {
//            SetAnimation(idle, true, 1f);
//        }

//        currentState = state;
//    }

//    public void Move()
//    {
//        movement = Input.GetAxis("Horizontal");
//        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
//        if (movement != 0)
//        {
//            if (!currentState.Equals("Jump"))
//            {
//                SetCharacterState("Run");
//            }
//            if (movement > 0)
//            {
//                transform.localScale = new Vector2(1f, 1f);
//            }
//            else
//            {
//                transform.localScale = new Vector2(-1f, 1f);
//            }
//        }
//        else 
//        {
//            if (!currentState.Equals("Jump"))
//            {
//                SetCharacterState("Idle");
//            }
//        }

//        if (Input.GetButtonDown("Jump"))
//        {
//            Jump();
//        }
//    }

//    public void Jump()
//    {
//        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
//        if (!currentState.Equals("Jump"))
//        {
//            previousState = currentState;
//        }
//        SetCharacterState("Jump");
//    }
}
