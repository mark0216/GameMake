using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : CommonMove
{
    [SerializeField] private int JumpTime;


    void Update()
    {
        GroundTouching = GroundAndWallDetect.GroundTouching;
        // �a�O������s

        if (GroundTouching)
        {
            VerticalSpeed = Mathf.Clamp(VerticalSpeed, 0, VerticalSpeedMax);
            JumpTime = 0;
        }
        // ���D���A���m

        if (Input.GetKey(KeyCode.A))
            HorizonVelocity(-1);
        else if (Input.GetKey(KeyCode.D))
            HorizonVelocity(1);
        else
            MiunsSpeed(); //�S������N�}�l��t
        // ���k���[��V

        if (Input.GetKeyDown(KeyCode.Space) && JumpTime < MaxJumpTimes)
        {
            VerticalVelocity();

            JumpTime++;
        }
        // ���D

        GravityEffect();
        // ���O�p��

        FinalSpeed = new Vector2(HorizonSpeed, VerticalSpeed);
        Rd.velocity = FinalSpeed;
        // ���ʳt�׭p��
    }
}
