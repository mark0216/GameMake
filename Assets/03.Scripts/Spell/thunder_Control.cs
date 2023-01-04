using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunder_Control : BaseSpellTrigger
{
    public Animator Anim_player;
    void Start()
    {
        Anim_player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim_player.GetCurrentAnimatorStateInfo(0).IsName("end"))
        {
            Destroy(this.gameObject);
        }
    }
    protected override void HitPlayer()
    {
    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
    }
}
