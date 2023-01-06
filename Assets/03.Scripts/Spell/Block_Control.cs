using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Control : MonoBehaviour
{
    [SerializeField] private float LifeTime = 5f;

    // Start is called before the first frame update
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
        Destroy(this.gameObject);
    }

}
