using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bearTrap_Control : BaseSpellTrigger
{
    [SerializeField] private float effectDuration = 5;
    [SerializeField] private SpriteRenderer myImage;
    [SerializeField] private Sprite mySprite1;
    [SerializeField] private Sprite mySprite2;

    void Start()
    {
        myImage.sprite = mySprite1;
    }
    protected override void HitPlayer()
    {
        player.GetComponent<CommonState>().AssignDazz(effectDuration, true);
        myImage.sprite = mySprite2;
        StartCoroutine(DelayPhaseProgress(effectDuration));
    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        Destroy(this.gameObject);
    }
}
