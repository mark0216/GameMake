using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_orange_control : BaseSpellTrigger
{
    [SerializeField] private float portalCD = 3;
    protected override void HitPlayer()
    {
        GameObject.Find("portal_blue").GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find("Player").transform.position = GameObject.Find("portal_blue").transform.position;
        StartCoroutine(DelayPhaseProgress(portalCD));
        
    }
    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        GameObject.Find("portal_blue").GetComponent<BoxCollider2D>().enabled = true;
    }
}
