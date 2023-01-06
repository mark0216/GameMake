using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Data", menuName = "Assets/Spell")]
public class SpellData : ScriptableObject
{
    public Data s_data;
}

[System.Serializable]
public class Data 
{
    public string name;
    public float cost;
    public float delayTime;
    public Sprite icon;
    public GameObject previewObj;
    public GameObject spell;
    public SpellType spellType;
}

public enum SpellType 
{
    projection,
    area,
    field,
    entity,
    special,
}


