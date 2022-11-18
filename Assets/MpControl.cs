using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MpControl : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject mpBar;
    [SerializeField] private Text mpValue;

    public float mpRecoverRate;
    public float currentMpValue;
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
}
