using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMove : MonoBehaviour
{
    public ChatacterData ChatacterData;
    protected Rigidbody2D Rd;
    [HideInInspector]public CommonState State;

    [HideInInspector] public int LastMoveDirection = 1; //角色最後朝向
    private Vector3 ScacleNow; // X值為角色當前朝向

    public bool UsingHorizonFlip; // 角色翻面模式

    protected float RollCD; // 翻滾CD時間

    [SerializeField] protected Vector2 FinalSpeed = new Vector2(0, 0); // 最終運動速度

    #region 水平速度控制
    private float HorizonSpeedMax = 0; //速度上限
    public float HorizonSpeed = 0; // 運算用 & 當前值

    public float AddSpeedAdjust; // 移動速度控制, 直接用 Time.DeltaTime 值太小
    private float OriginAddSpeedAdjust;

    public float MinusSpeedAdjust; // 移動速度控制, 直接用 Time.DeltaTime 值太小
    private float OriginMinusSpeedAdjust;

    private float AddSpeed; // 加速度初始值
    private float MinusSpeed; // 減速度初始值   
    #endregion

    #region 垂直速度控制
    protected float VerticalSpeedMax = 0; //速度上限
    public float VerticalSpeed = 0; // 運算用 & 當前值

    private float Gravity; // 重力初始值
    public float GravityAdjust; // 重力調整值 
    public float GravityMax; // 重力最大值

    protected int MaxJumpTimes; // 最大跳躍次數

    protected bool GroundTouching; // 地板偵測
    #endregion

    private float BeforeDashSpeed;
    private float BeforeDahsMoveDirection;
    public float DashLength;

    #region 組件

    protected GroundAndWallDetect GroundAndWallDetect;
    protected CommonAnimtion CommonAnimtion;

    #endregion

    void Start()
    {
        HorizonSpeedMax = ChatacterData.MaxMoveSpeed;
        VerticalSpeedMax = ChatacterData.JumpSpeed;

        AddSpeed = ChatacterData.AddSpeed;
        MinusSpeed = ChatacterData.MinusSpeed;


        Gravity = ChatacterData.Gravity;
        MaxJumpTimes = ChatacterData.AirJumpTimes;

        Rd = this.GetComponent<Rigidbody2D>();

        State = this.GetComponent<CommonState>();

        GroundAndWallDetect = this.GetComponent<GroundAndWallDetect>();
        CommonAnimtion = this.GetComponent<CommonAnimtion>();   

        OriginAddSpeedAdjust = AddSpeedAdjust;
        OriginMinusSpeedAdjust = MinusSpeedAdjust;

        RollCD = ChatacterData.RollCD;
    }

    protected void HorizonVelocity(int Direction) // 水平速度控制(+1往右 -1往左)
    {
        if (Direction != LastMoveDirection && UsingHorizonFlip)
            HorizonFlip();

        //if (HorizonSpeed > HorizonSpeedLimited)
        //    AddSpeedAdjust = AddSpeedAdjustOri * 0.05f;
        //else if (HorizonSpeedLimited < MinusSpeedAdjust)
        //    AddSpeedAdjust = AddSpeedAdjustOri;

        HorizonSpeed += AddSpeed * Direction * Time.deltaTime * AddSpeedAdjust; // v = v0 + at*調整值

        HorizonSpeed = Mathf.Clamp(HorizonSpeed, -HorizonSpeedMax, HorizonSpeedMax); // 避免超過速度上限

        LastMoveDirection = Direction; // 紀錄當前移動方向,轉向和減速用
    }
    protected void HorizonFlip()
    {
        ScacleNow = this.gameObject.transform.lossyScale;

        ScacleNow.x *= -1;

        this.gameObject.transform.localScale = ScacleNow;
    }
    protected void MiunsSpeed()
    {
        //  Debug.Log("minus speed is working");

        HorizonSpeed -= MinusSpeed * LastMoveDirection * Time.deltaTime * MinusSpeedAdjust;
        // 計算當前速度

        if (LastMoveDirection == 1)
        {
            HorizonSpeed = Mathf.Clamp(HorizonSpeed, 0, HorizonSpeedMax);
        }
        else if (LastMoveDirection == -1)
        {
            HorizonSpeed = Mathf.Clamp(HorizonSpeed, -HorizonSpeedMax, 0);
        }
        // 限制移動速度最大最小值
        // 減速 最大或最小為0
    }
    protected void VerticalVelocity()
    {
        //Debug.Log("Vertical move work");

        VerticalSpeed = VerticalSpeedMax;

        // 將垂直速度變更為上限 
        // 跳躍用
    }
    protected void GravityEffect()
    {
        VerticalSpeed -= Gravity * Time.deltaTime * GravityAdjust;
        // 計算當前速度

        if (!GroundTouching)
            VerticalSpeed = Mathf.Clamp(VerticalSpeed, GravityMax, VerticalSpeedMax);

        // 限制移動速度最大最小值
        // 減速 最大或最小為0
    }

    // Gravity

    public IEnumerator Brake(float MaintainLength)
    {
        Debug.Log("brake");
        HorizonSpeed = 0;
        AddSpeedAdjust = 0;

        // 急煞
        // 將速度與加速度歸0

        yield return new WaitForSecondsRealtime(MaintainLength);
    }

    public IEnumerator Dash()
    {
        Debug.Log("Dash");

        HorizonSpeedMax = HorizonSpeedMax * 2;

        BeforeDashSpeed = HorizonSpeed;
        HorizonSpeed = 10 * 2 * LastMoveDirection;
        yield return new WaitForSeconds(DashLength);

        if(LastMoveDirection == BeforeDahsMoveDirection)
            HorizonSpeed = BeforeDashSpeed;

        HorizonSpeedMax = ChatacterData.MaxMoveSpeed;


        // 短距離衝刺
        // 將水平速度變更為上限 
    }

    public void AssignSpeed(float MaintainLength)
    {
        StartCoroutine(AssignSpeedIE(MaintainLength));
    }

    private IEnumerator AssignSpeedIE(float MaintainLength)
    {
        HorizonSpeedMax = ChatacterData.AssignSpeed;
        HorizonSpeed = HorizonSpeedMax;

        yield return new WaitForSecondsRealtime(MaintainLength);

        HorizonSpeedMax = ChatacterData.MaxMoveSpeed;
    }

    // Action






}
