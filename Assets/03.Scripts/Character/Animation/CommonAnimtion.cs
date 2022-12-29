using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAnimtion : MonoBehaviour
{
    private Animator Animator;
    private PlayerMove PlayerMove;
    private GroundAndWallDetect GroundAndWallDetect;

    private string JumpTriggerName = "VerticalSpeed";
    private string RunTriggerName = "HorizonSpeed";

    void Start()
    {
        Animator = this.GetComponent<Animator>();

        PlayerMove = this.GetComponent<PlayerMove>();

        GroundAndWallDetect = this.GetComponent<GroundAndWallDetect>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpeed();
        LandingTrigger();

        Animator.SetInteger("JumpTime", PlayerMove.JumpTime);
    }

    public void JumpTrigger()
    {
        Animator.SetTrigger("Jump");
       
    }

    public void DazzTrigger()
    {
        Animator.SetTrigger("Dazz");
    }

    protected void LandingTrigger()
    {
        Animator.SetBool("GroundTouching", GroundAndWallDetect.GroundTouching);
    }

    protected void MoveSpeed()
    {
   //     Animator.SetFloat(JumpTriggerName, CommonMove.VerticalSpeed);
        Animator.SetFloat(RunTriggerName, Mathf.Abs(PlayerMove.HorizonSpeed));
    }
}
