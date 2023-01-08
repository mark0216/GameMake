using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBottle_Control : BaseSpellTrigger
{
    [SerializeField] private Text ClickText;
    [SerializeField] private Text ManaText;
    [SerializeField] private AudioSource audioGain;
    [SerializeField] private AudioSource audioBreak;

    [SerializeField] private GameObject UI;

    [SerializeField] private float ClickTime = 10;
    [SerializeField] private float ManaValue = 5;



    // Start is called before the first frame update
    void Start()
    {
        refresh();
    }
    void OnMouseDown()
    {
        ClickTime--;
        refresh();
        if (ClickTime <= 0)
        {
            doGainMana(ManaValue);
        }
    }
    protected override void HitPlayer()
    {
        audioBreak.Play(0);
        StartCoroutine(DelayDestoryEvent(2));
    }
    private void refresh()
    {
        ClickText.text = ClickTime.ToString();
        ManaText.text = ManaValue.ToString();
    }
    private void doGainMana(float ManaValue)
    {
        audioGain.Play(0);
        MpControl.instance.GainMana(ManaValue);
        Debug.Log("Gain " + ManaValue.ToString() + " Mana");
        StartCoroutine(DelayDestoryEvent(2));

    }
    IEnumerator DelayDestoryEvent(float delaySec)
    {
        UI.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(delaySec);
        Destroy(this.gameObject);
    }
}
