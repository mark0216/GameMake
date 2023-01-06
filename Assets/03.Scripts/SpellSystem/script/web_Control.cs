using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class web_Control : BaseSpellTrigger
{
    [SerializeField] private float Lifetime = 5f;
    [SerializeField] private float effectDuration = 5;
    private bool isWeb = false;

    void Start()
    {
        if (Lifetime > 0)
        {
            StartCoroutine(DelayLifetimeProgress(Lifetime));
        }
    }
    protected override void HitPlayer()
    {
        GameObject.Find("Player").GetComponent<CommonState>().AssignDazz(effectDuration,true);
        StartCoroutine(DelayPhaseProgress(effectDuration));
    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        isWeb = true;
        yield return new WaitForSeconds(delaySec);
        Destroy(this.gameObject);
    }
    IEnumerator DelayLifetimeProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        if (isWeb)
        {
            yield return new WaitForSeconds(1f);
        }
        Destroy(this.gameObject);
    }
}
