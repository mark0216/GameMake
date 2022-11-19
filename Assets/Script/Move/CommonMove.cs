using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMove : MonoBehaviour
{
    public ChatacterData ChatacterData;
    protected Rigidbody2D Rd;

    [HideInInspector] public int LastMoveDirection = 1; //����̫�¦V
    private Vector3 ScacleNow; // X�Ȭ������e�¦V
    public bool UsingHorizonFlip;

    protected float RollCD;

    [SerializeField] protected Vector2 FinalSpeed = new Vector2(0, 0); // �̲׹B�ʳt��

    #region �����t�ױ���
    private float HorizonSpeedMax = 0; //�t�פW��
    public float HorizonSpeed = 0; // �B��� & ��e��

    public float AddSpeedAdjust; // ���ʳt�ױ���, ������ Time.DeltaTime �ȤӤp
    private float OriginAddSpeedAdjust;

    public float MinusSpeedAdjust; // ���ʳt�ױ���, ������ Time.DeltaTime �ȤӤp
    private float OriginMinusSpeedAdjust;

    private float AddSpeed; // �[�t�ת�l��
    private float MinusSpeed; // ��t�ת�l��   
    #endregion

    #region �����t�ױ���
    protected float VerticalSpeedMax = 0; //�t�פW��
    public float VerticalSpeed = 0; // �B��� & ��e��

    private float Gravity; // ���O��l��
    public float GravityAdjust; // ���O�վ�� 
    public float GravityMax; // ���O�̤j��

    protected int MaxJumpTimes; // �̤j���D����

    protected bool GroundTouching; // �a�O����
    #endregion

    #region �ե�

    protected GroundAndWallDetect GroundAndWallDetect;

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

        GroundAndWallDetect = this.GetComponent<GroundAndWallDetect>();

        OriginAddSpeedAdjust = AddSpeedAdjust;
        OriginMinusSpeedAdjust = MinusSpeedAdjust;

        RollCD = ChatacterData.RollCD;
    }

    protected void HorizonVelocity(int Direction) // �����t�ױ���(+1���k -1����)
    {
        if (Direction != LastMoveDirection && UsingHorizonFlip)
            HorizonFlip();

        HorizonSpeed += AddSpeed * Direction * Time.deltaTime * AddSpeedAdjust; // v = v0 + at*�վ��
        HorizonSpeed = Mathf.Clamp(HorizonSpeed, -HorizonSpeedMax, HorizonSpeedMax); // �קK�W�L�t�פW��

        LastMoveDirection = Direction; // ������e���ʤ�V,��V�M��t��
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

        if (LastMoveDirection == 1)
        {
            HorizonSpeed = Mathf.Clamp(HorizonSpeed, 0, HorizonSpeedMax);
        }
        else if (LastMoveDirection == -1)
        {
            HorizonSpeed = Mathf.Clamp(HorizonSpeed, -HorizonSpeedMax, 0);
        }

        // ��t �̤j�γ̤p��0
    }
    protected void VerticalVelocity()
    {
        //Debug.Log("Vertical move work");

        VerticalSpeed = VerticalSpeedMax;
    }
    protected void GravityEffect()
    {
        VerticalSpeed -= Gravity * Time.deltaTime * GravityAdjust;

        VerticalSpeed = Mathf.Clamp(VerticalSpeed, GravityMax, VerticalSpeedMax);
    }

    // Gravity

    public void Brake() // ��� �N�t�׻P�[�t���k0
    {
        Debug.Log("brake");
        HorizonSpeed = 0;
        AddSpeedAdjust = 0;
    }

    public void Dash() // �u�Z���Ĩ�
    {
        Debug.Log("Dash");
        HorizonSpeed = HorizonSpeedMax * LastMoveDirection;
        MinusSpeedAdjust = 0;
    }

    public void AddSpeedReset() // ��ٵ������ �N�[�t�צ^�k���`
    {
        AddSpeedAdjust = OriginAddSpeedAdjust;
    }

    public void MinusSpeedReset() // �u�Z���Ĩ���  
    {
        MinusSpeedAdjust = OriginMinusSpeedAdjust;
    }

    // Action






}
