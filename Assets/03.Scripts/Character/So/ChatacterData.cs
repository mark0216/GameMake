using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterData")]
public class ChatacterData : ScriptableObject
{
    [Header("element horizon speed contorl")]
    public float MaxMoveSpeed; // �����̤j�t��
    public float AddSpeed; // �����[�t��
    public float MinusSpeed; // ������t�� 

    [Header("assign speed")]
    public float AssignSpeed;

    [Header("element vertical speed contorl")]
    public float Gravity; // ���O
    public float JumpSpeed; // �����̤j�t��
    public int AirJumpTimes; // �̤j���D����

    [Header("element fight value")]
    public float HP;
    public float Atk;
    public float Def;
    public float AtkCD;
    public float RollCD;
}
