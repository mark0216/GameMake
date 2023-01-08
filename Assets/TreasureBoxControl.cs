using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBoxControl : BaseSpellTrigger
{
    protected override void HitPlayer()
    {
        print("player A wins");
        gameManager.instance.GameOver(0);
    }
}
