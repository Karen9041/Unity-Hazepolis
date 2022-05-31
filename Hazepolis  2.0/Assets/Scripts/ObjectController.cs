using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectController : MonoBehaviour
{
    private Animator animator;
    //private float magicState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("speed", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ControlTime(float timer)
    {
        Debug.Log("ControlTime" + timer);
        animator.SetFloat("speed", timer);
        //magicState = timer;
    }
    public void PauseTime()
    {
        Debug.Log("PauseTime");
        animator.SetFloat("speed", 0);
        //magicState = 0;
    }
}
