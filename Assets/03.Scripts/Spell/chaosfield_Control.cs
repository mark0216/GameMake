using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaosfield_Control : BaseSpellTrigger
{
    [SerializeField] private float effectDuration = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void HitPlayer()
    {
        FindObjectOfType<PlayerMove>().isChaos = true;
        StartCoroutine(DelayPhaseProgress(effectDuration));


    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        FindObjectOfType<PlayerMove>().isChaos = false;
    }
}
