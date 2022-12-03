using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : CommonMove
{
    public int JumpTime;


    void Update()
    {
        GroundTouching = GroundAndWallDetect.GroundTouching;
        // �a�O������s

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

        if (Input.GetKey(KeyCode.A))
            HorizonVelocity(-1);
        else if (Input.GetKey(KeyCode.D))
            HorizonVelocity(1);
        else
            MiunsSpeed(); //�S������N�}�l��t
        // ���k���[��V

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (JumpTime < MaxJumpTimes)
            {
                JumpTime++;
                VerticalVelocity();

                CommonAnimtion.JumpTrigger();
            }
        }
        // ���D

        GravityEffect();
        // ���O�p��

        FinalSpeed = new Vector2(HorizonSpeed, VerticalSpeed);
        Rd.velocity = FinalSpeed;
        // ���ʳt�׭p��
    }

    private void LateUpdate()
    {
     
    }
}
