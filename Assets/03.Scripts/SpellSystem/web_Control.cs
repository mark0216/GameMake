using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class web_Control : BaseSpellTrigger
{
    [SerializeField] private float effectDuration = 5;


    protected override void HitPlayer()
    {
        FindObjectOfType<CommonState>().Dazzing = true;
        GameObject.Find("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        StartCoroutine(DelayPhaseProgress(effectDuration));
    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        FindObjectOfType<CommonState>().Dazzing = false;
        GameObject.Find("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Destroy(this.gameObject);
    }
}
