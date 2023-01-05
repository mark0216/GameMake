using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : CommonMove
{
    [HideInInspector] public int JumpTime;
    public bool isChaos=false;

    void Update()
    {
        GroundTouching = GroundAndWallDetect.GroundTouching;
        // �a�O������s

        if (!State.Dazzing)
        {
            if (GroundTouching)
            {
                VerticalSpeed = Mathf.Clamp(VerticalSpeed, 0, VerticalSpeedMax);
                JumpTime = 0;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(Dash());
            }
            // ���D���A���m
            if (isChaos)
            {
                if (Input.GetKey(KeyCode.A))
                    HorizonVelocity(1);
                else if (Input.GetKey(KeyCode.D))
                    HorizonVelocity(-1);
                else
                    MiunsSpeed(); //�S������N�}�l��t
                                  // ���k���[��V
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                    HorizonVelocity(-1);
                else if (Input.GetKey(KeyCode.D))
                    HorizonVelocity(1);
                else
                    MiunsSpeed();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (JumpTime < MaxJumpTimes && Time.time > LastJumpTime + ChatacterData.JumpCD)
                {
                    LastJumpTime = Time.time;
                    JumpTime++;
                    VerticalVelocity(1);

                    CommonAnimtion.JumpTrigger();
                }
            }
            // ���D
        }
        
        if(State.Dazzing)
        {
            Brake(Time.deltaTime);
            CommonAnimtion.DazzTrigger();
        }

        GravityEffect();
        // ���O�p��

        FinalSpeed = new Vector2(HorizonSpeed, VerticalSpeed);
        Rd.velocity = FinalSpeed;
        // ���ʳt�׭p��
    }
    public void juumpEffect(float tmp)
    {
        VerticalVelocity(tmp);
    }
   
}
