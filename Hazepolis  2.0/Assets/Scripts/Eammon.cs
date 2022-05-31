using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eammon : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;
    private string previousState, currentState ;
    private Rigidbody2D rigid2D;
    //private Animator animator;
    private float jumpForce = 2000.0f;
    public float walkForce = 25.0f;
    public float maxWalkForce = 6.0f;
    private bool isJumping = false;
    private bool afterSu = false;
    private int key ;

    bool inputEnabled = false;

    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        rigid2D = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        skeletonAnimation.state.SetAnimation(0, "sleep", false);
        currentState = "sleep";
    }
    void Update()
    {
        if (inputEnabled == true)
        {
            EammonMove();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Box") && afterSu)
        {
            isJumping = false;
            skeletonAnimation.state.SetAnimation(0, currentState, true);
        }
    }
    private void WakeUp()
    {
        afterSu = true;
    }
    private void EammonMove()
    {
        if (afterSu == false)
        {
            previousState = currentState;
            currentState = "su";
            if (previousState != currentState)
            {
                skeletonAnimation.state.SetAnimation(0, currentState, false);
            }
            else
            {
                Invoke("WakeUp", 7f);
            }
            previousState = currentState;
        }
        else if (afterSu)
        {
            key = 0;
            //jump
            if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                isJumping = true;
                rigid2D.AddForce(transform.up * jumpForce);
                skeletonAnimation.state.SetAnimation(0, "jump", false);
            }
            //basic movement
            if (Input.GetKey(KeyCode.A))
            {
                key = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                key = 1;
            }
            //Crouch or Standing
            if (Input.GetKey(KeyCode.S)){
                currentState = key == 0 ? "Crouch idle2" : "Crouch walk2";
                maxWalkForce = 3.0f;
            }
            else
            {
                currentState = key == 0 ? "idle" : "walk";
                maxWalkForce = 6.0f;
            }

            float speedx = Mathf.Abs(this.rigid2D.velocity.x);
            if (speedx < maxWalkForce)
            {
                rigid2D.AddForce(transform.right * key * walkForce);

            }
            if (previousState != currentState)
            {
                skeletonAnimation.state.SetAnimation(0, currentState, true);
            }
            previousState = currentState;

            if (key != 0)
            {
                skeletonAnimation.Skeleton.ScaleX = key > 0 ? -1f : 1f;
            }
        }
    }
    private void Magic()
    {
        skeletonAnimation.state.SetAnimation(0, "magic", false);
    }

    private void Magic2()
    {
        skeletonAnimation.state.SetAnimation(0, "magic 2", false);
    }

    public void Activate()
    {
        inputEnabled = true;
    }

    public void Deactivate()
    {
        inputEnabled = false;
    }
}


