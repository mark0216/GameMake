using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBottle_Control : MonoBehaviour
{
    [SerializeField] private Text ClickText;
    [SerializeField] private Text ManaText;
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
    private void refresh()
    {
        ClickText.text = ClickTime.ToString();
        ManaText.text = ManaValue.ToString();
    }
    private void doGainMana(float ManaValue)
    {
        MpControl.instance.GainMana(ManaValue);
        Debug.Log("Gain " + ManaValue.ToString() + " Mana");
        DestoryEvent();
    }
    public void DestoryEvent()
    {
        Destroy(this.gameObject);
    }
}
