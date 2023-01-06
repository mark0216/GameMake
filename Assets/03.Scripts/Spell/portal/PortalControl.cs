using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : BaseSpellTrigger
{
    [SerializeField] private GameObject targetPortal;
    private float portalCD = 1.5f;

    protected override void HitPlayer()
    {
        targetPortal.GetComponent<BoxCollider2D>().enabled = false;
        player.transform.position = targetPortal.transform.position;
        StartCoroutine(DelayPhaseProgress(portalCD));
        
    }
    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        targetPortal.GetComponent<BoxCollider2D>().enabled = true;
    }
}
