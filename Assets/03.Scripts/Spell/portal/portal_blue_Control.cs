using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_blue_Control : BaseSpellTrigger
{
    [SerializeField] private float Lifetime = 5f;
    [SerializeField] private float CD_Tiimer=3;
    [SerializeField] private GameObject portal_orange;
    void Start()
    {
        if (Lifetime > 0)
        {
            StartCoroutine(DelayLifetimeProgress(Lifetime));
        }
    }
    protected override void HitPlayer()
    {
        portal_orange.GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find("Player").transform.position = portal_orange.transform.position;
        StartCoroutine(DelayPhaseProgress(CD_Tiimer));

    }
    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        portal_orange.GetComponent<BoxCollider2D>().enabled = true;
    }
    IEnumerator DelayLifetimeProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        Destroy(this.gameObject);
    }
}
