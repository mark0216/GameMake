using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MpControl : MonoBehaviour
{
    public static MpControl instance;

    [Header("Canvas")]
    [SerializeField] private GameObject mpBar;
    [SerializeField] private Text mpValue;

    public float mpRecoverRate;
    public float currentMpValue { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        MpCalculate();
        UpdateCanvas();
    }

    private void UpdateCanvas()
    {
        mpBar.GetComponent<RectTransform>().localScale = new Vector3(1, currentMpValue / 10, 1);
        mpValue.text = currentMpValue.ToString("0");
    }
    private void MpCalculate()
    {
        currentMpValue += mpRecoverRate * Time.deltaTime;
        currentMpValue = Mathf.Clamp(currentMpValue, 0, 10);
        UpdateCanvas();
    }
    public void ReduceMp(float value)
    {
        currentMpValue -= value;
    }
    public void GainMana(float value)
    {
        currentMpValue += value;
    }
}
