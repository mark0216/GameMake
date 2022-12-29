using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : CommonMove
{
    public int JumpTime;
    void Update()
    {
        GroundTouching = GroundAndWallDetect.GroundTouching;
        // 地板偵測更新

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
            // 跳躍狀態重置

            if (Input.GetKey(KeyCode.A))
                HorizonVelocity(-1);
            else if (Input.GetKey(KeyCode.D))
                HorizonVelocity(1);
            else
                MiunsSpeed(); //沒按按鍵就開始減速
                              // 左右走加轉向

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (JumpTime < MaxJumpTimes)
                {
                    JumpTime++;
                    VerticalVelocity();

                    CommonAnimtion.JumpTrigger();
                }
            }
            // 跳躍
        }
        
        if(State.Dazzing)
        {
            Brake(Time.deltaTime);
        }

        GravityEffect();
        // 重力計算

        FinalSpeed = new Vector2(HorizonSpeed, VerticalSpeed);
        Rd.velocity = FinalSpeed;
        // 移動速度計算
    }

   
}
