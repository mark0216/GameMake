using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Database", menuName = "Assets/Databases/Item Database")]
public class SpellDataBase : ScriptableObject
{
    public List<SpellData> allSpells;
}
