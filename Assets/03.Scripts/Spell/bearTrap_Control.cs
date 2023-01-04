using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearTrap_Control : BaseSpellTrigger
{
    [SerializeField] private float effectDuration = 5;
    
    protected override void HitPlayer()
    {
        FindObjectOfType<CommonState>().Dazzing=true;
        StartCoroutine(DelayPhaseProgress(effectDuration));
    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        FindObjectOfType<CommonState>().Dazzing = false;
        Destroy(this.gameObject);
    }
}
