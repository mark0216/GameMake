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
    [SerializeField] private GameObject audioSource;

    void Start()
    {
        myImage.sprite = mySprite1;
        player = GameObject.FindGameObjectsWithTag("Player")[0];

    }
    protected override void HitPlayer()
    {
        audioSource.SetActive(true);
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
