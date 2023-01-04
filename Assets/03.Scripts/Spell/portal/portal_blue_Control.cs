using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_blue_Control : BaseSpellTrigger
{
    [SerializeField] private float CD_Tiimer=3;
    protected override void HitPlayer()
    {
        GameObject.Find("portal_orange").GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find("Player").transform.position = GameObject.Find("portal_orange").transform.position;
        StartCoroutine(DelayPhaseProgress(CD_Tiimer));

    }
    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        GameObject.Find("portal_orange").GetComponent<BoxCollider2D>().enabled = true;
    }
}
