using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterData")]
public class ChatacterData : ScriptableObject
{
    [Header("element horizon speed contorl")]
    public float MaxMoveSpeed; // キ程硉
    public float AddSpeed; // キ硉
    public float MinusSpeed; // キ搭硉 

    [Header("assign speed")]
    public float AssignSpeed;

    [Header("element vertical speed contorl")]
    public float Gravity; // 
    public float JumpSpeed; // 程硉
    public int AirJumpTimes; // 程铬臘Ω计

    [Header("element fight value")]
    public float HP;
    public float Atk;
    public float Def;
    public float AtkCD;
    public float RollCD;
}
