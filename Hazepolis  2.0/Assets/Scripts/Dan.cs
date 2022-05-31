using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dan : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;
    private string previousState, currentState;
    private Rigidbody2D rigid2D;
    //private float jumpForce = 2000.0f;
    private float walkForce = 20.0f;
    private float maxWalkForce = 4.0f;
    //private bool isJumping = false;
    private int key;

    bool inputEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputEnabled == true)
        {
            DanMove();
        }
    }

    private void DanMove()
    {
        key = 0;
        //if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        //{
        //    isJumping = true;
        //    rigid2D.AddForce(transform.up * jumpForce);
        //    skeletonAnimation.state.SetAnimation(0, "jump", false);
        //}
        if (Input.GetKey(KeyCode.A))
        {
            key = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            key = 1;
        }
        currentState = key == 0 ? "magic" : "animation";

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

    public void Activate()
    {
        inputEnabled = true;
    }

    public void Deactivate()
    {
        inputEnabled = false;
    }
}
