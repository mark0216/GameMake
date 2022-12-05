using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterData")]
public class ChatacterData : ScriptableObject
{
    public float MaxMoveSpeed; // キ程硉
    public float AddSpeed; // キ硉
    public float MinusSpeed; // キ搭硉 

    public float Gravity; // 
    public float JumpSpeed; // 程硉
    public int AirJumpTimes; // 程铬臘Ω计

    public float HP;
    public float Atk;
    public float Def;

    public float AtkCD;
    public float RollCD;
}
