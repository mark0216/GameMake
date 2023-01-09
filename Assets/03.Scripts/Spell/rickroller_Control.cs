using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rickroller_Control : BaseSpellTrigger
{
    [SerializeField] private GameObject videoPlayer;
    protected override void HitPlayer()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Instantiate(videoPlayer);
    }
    public void DestoryEvent()
    {
        Destroy(this.gameObject);
    }
}
