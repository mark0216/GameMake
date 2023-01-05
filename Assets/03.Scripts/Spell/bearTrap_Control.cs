using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bearTrap_Control : BaseSpellTrigger
{
    [SerializeField] private float effectDuration = 5;
    public SpriteRenderer myImage;

    public Sprite mySprite1;
    public Sprite mySprite2;

    void Start()
    {
        myImage.sprite = mySprite1;
    }
    protected override void HitPlayer()
    {
        FindObjectOfType<CommonState>().Dazzing=true;
        myImage.sprite = mySprite2;

        StartCoroutine(DelayPhaseProgress(effectDuration));
    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        FindObjectOfType<CommonState>().Dazzing = false;
        Destroy(this.gameObject);
    }
}
