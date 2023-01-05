using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMask : MonoBehaviour
{
    public void setMask(float time)
    {
        StartCoroutine(DelayPhaseProgress(time));

    }
    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        this.gameObject.SetActive(false);
    }
}
