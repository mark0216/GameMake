using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bearTrap_Control : BaseSpellTrigger
{
    [SerializeField] private float Lifetime = 5f;
    [SerializeField] private float effectDuration = 5;
    public SpriteRenderer myImage;
    public Sprite mySprite1;
    public Sprite mySprite2;
    private bool isTrap = false;

    void Start()
    {
        myImage.sprite = mySprite1;
        if (Lifetime > 0)
        {
            StartCoroutine(DelayLifetimeProgress(Lifetime));
        }
    }
    protected override void HitPlayer()
    {
        GameObject.Find("Player").GetComponent<CommonState>().AssignDazz(effectDuration, true);
        myImage.sprite = mySprite2;
        StartCoroutine(DelayPhaseProgress(effectDuration));
    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        isTrap = true;
        yield return new WaitForSeconds(delaySec);
        Destroy(this.gameObject);
    }
    IEnumerator DelayLifetimeProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        if (isTrap)
        {
            yield return new WaitForSeconds(1f);
        }
        Destroy(this.gameObject);
    }
}
