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
    [SerializeField] private float HorizonSpeedMax = 0; //速度上限
    public float HorizonSpeed = 0; // 運算用 & 當前值

    public float AddSpeedAdjust; // 移動速度控制, 直接用 Time.DeltaTime 值太小
    private float OriginAddSpeedAdjust;

    public float MinusSpeedAdjust; // 移動速度控制, 直接用 Time.DeltaTime 值太小
    private float OriginMinusSpeedAdjust;

    private float AddSpeed; // 加速度初始值
    private float MinusSpeed; // 減速度初始值   
    #endregion

    #region 垂直速度控制
    [SerializeField] protected float VerticalSpeedMax = 0; //速度上限
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

    protected float LastJumpTime;

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
        LastJumpTime = Time.time;
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

        HorizonSpeed = 0;
    }
    protected void MiunsSpeed()
    {
        if (HorizonSpeed > 0)
        {
            HorizonSpeed -= MinusSpeed * 1 * Time.deltaTime * MinusSpeedAdjust;
            if (HorizonSpeed < 0)
                HorizonSpeed = 0;
        }
        else if(HorizonSpeed < 0)
        {
            HorizonSpeed -= MinusSpeed * -1 * Time.deltaTime * MinusSpeedAdjust;
            if (HorizonSpeed > 0)
                HorizonSpeed = 0;
        }
        HorizonSpeed = Mathf.Clamp(HorizonSpeed, -HorizonSpeedMax, HorizonSpeedMax);
        // 計算當前速度
        // 限制移動速度最大最小值
        // 減速 最大或最小為0
    }
    protected void VerticalVelocity(float Adjust)
    {
        //Debug.Log("Vertical move work");

        VerticalSpeed = VerticalSpeedMax * Adjust;

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

    public void AssignForce(float ForceXray, float ForceYray,float effectHigh)
    {
        SetAirSpeed(0.5f, effectHigh, 13f);
        AssignSpeedPostive(0.5f);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        HorizonSpeed = ForceXray;
        VerticalSpeed = ForceYray;

        // forcexray +朝右 -朝左
        // forceyray +朝上 -朝下
    }

    public void AssingForceTest()
    {

        AssignForce(10, 10, 20);
    }

    public void AssignSpeedPostive(float MaintainLength)
    {
        StartCoroutine(AssignSpeedPostiveIE(MaintainLength));
    }
    public void SetSpeedPostive(float Limit)
    {
        HorizonSpeedMax = Limit;
    }

    private IEnumerator AssignSpeedPostiveIE(float MaintainLength)
    {
        HorizonSpeedMax = ChatacterData.AssignSpeedPostive;

        yield return new WaitForSecondsRealtime(MaintainLength);

        HorizonSpeedMax = ChatacterData.MaxMoveSpeed;
    }

    public void AssignSpeedNegtive(float MaintainLength)
    {
        StartCoroutine(AssignSpeedNegtiveIE(MaintainLength));
    }

    private IEnumerator AssignSpeedNegtiveIE(float MaintainLength)
    {
        HorizonSpeedMax = ChatacterData.AssignSpeedNegtive;

        yield return new WaitForSecondsRealtime(MaintainLength);

        HorizonSpeedMax = ChatacterData.MaxMoveSpeed;
    }
    
    public void SetAirSpeed(float MaintainLength, float Effect, float Origin)
    {
        StartCoroutine(AssignAirSpeed(MaintainLength, Effect, Origin));

    }
    private IEnumerator AssignAirSpeed(float MaintainLength,float Effect,float Origin)
    {
        VerticalSpeedMax = Effect;

        yield return new WaitForSecondsRealtime(MaintainLength);

        VerticalSpeedMax = Origin;
    }

    // Action






}
