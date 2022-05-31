using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMove : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;
    private string previousState, currentState;
    private Rigidbody2D rigid2D;
    private float jumpForce = 2000.0f;
    private float walkForce = 25.0f;
    private float maxWalkForce = 6.0f;
    private bool isJumping = false;
    private bool afterSu = false;
    private int key;
    bool inputEnabled = false;
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        rigid2D = GetComponent<Rigidbody2D>();
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
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
            skeletonAnimation.state.SetAnimation(0, currentState, true);
        }
    }

    public void EammonMove()
    {
        if (afterSu == false)
        {
            currentState = "su";
            skeletonAnimation.state.SetAnimation(0, currentState, false).End += delegate
            {
                (skeletonAnimation.state.SetAnimation(0, "su", false)).TimeScale = 0.8f;
                afterSu = true;
            };
        }
        else if (afterSu)
        {
            key = 0;
            if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                isJumping = true;
                rigid2D.AddForce(transform.up * jumpForce);
                skeletonAnimation.state.SetAnimation(0, "jump", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                key = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                key = 1;
            }
            currentState = key == 0 ? "idle" : "walk";

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
    public void Activate()
    {
        inputEnabled = true;
    }

    public void Deactivate()
    {
        inputEnabled = false;
    }
}


