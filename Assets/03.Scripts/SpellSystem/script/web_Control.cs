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
        player = GameObject.FindGameObjectsWithTag("Player")[0];

        if (Lifetime > 0)
        {
            StartCoroutine(DelayLifetimeProgress(Lifetime));
        }
    }
    protected override void HitPlayer()
    {
        player.GetComponent<CommonState>().AssignDazz(effectDuration,true);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        StartCoroutine(DelayPhaseProgress(effectDuration));
    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        isWeb = true;
        yield return new WaitForSeconds(delaySec);
       // isWeb = false;
        Destroy(this.gameObject);
    }
    IEnumerator DelayLifetimeProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        while (isWeb)
        {
            yield return new WaitForSeconds(1f);
        }
        Destroy(this.gameObject);
    }
}
