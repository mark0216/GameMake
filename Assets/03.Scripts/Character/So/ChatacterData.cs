using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterData")]
public class ChatacterData : ScriptableObject
{
    public float MaxMoveSpeed; // �����̤j�t��
    public float AddSpeed; // �����[�t��
    public float MinusSpeed; // ������t�� 

    public float Gravity; // ���O
    public float JumpSpeed; // �����̤j�t��
    public int AirJumpTimes; // �̤j���D����

    public float HP;
    public float Atk;
    public float Def;

    public float AtkCD;
    public float RollCD;
}
