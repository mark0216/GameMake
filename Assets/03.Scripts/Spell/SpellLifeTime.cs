using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLifeTime : MonoBehaviour
{
    [SerializeField] protected float LifeTime;

    void Start()
    {
        if (LifeTime > 0)
        {
            StartCoroutine(DelayLifetimeProgress(LifeTime));
        }
    }
    IEnumerator DelayLifetimeProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        Destroy(this.gameObject, 0.1f);
    }

}
