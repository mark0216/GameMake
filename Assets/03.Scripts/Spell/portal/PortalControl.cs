﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : BaseSpellTrigger
{
    [SerializeField] private GameObject targetPortal;
    private float portalCD = 1.5f;
    [SerializeField] private AudioSource audioSource;

    protected override void HitPlayer()
    {
        audioSource.Play(0);
        targetPortal.GetComponent<BoxCollider2D>().enabled = false;
        player.transform.position = targetPortal.transform.position + new Vector3(0, 1.5f, 0);
        StartCoroutine(DelayPhaseProgress(portalCD));

    }
    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        targetPortal.GetComponent<BoxCollider2D>().enabled = true;
    }
}
