using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_orange_control : BaseSpellTrigger
{
    [SerializeField] private float Lifetime = 5f;
    [SerializeField] private float portalCD = 3;
    [SerializeField] private GameObject portal_blue;
    void Start()
    {
        if (Lifetime > 0)
        {
            StartCoroutine(DelayLifetimeProgress(Lifetime));
        }
    }
    protected override void HitPlayer()
    {
        portal_blue.GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find("Player").transform.position = portal_blue.transform.position;
        StartCoroutine(DelayPhaseProgress(portalCD));
        
    }
    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        portal_blue.GetComponent<BoxCollider2D>().enabled = true;
    }
    IEnumerator DelayLifetimeProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        Destroy(this.gameObject);
    }
}
