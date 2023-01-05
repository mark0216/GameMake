using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMask : MonoBehaviour
{
    void Update()
    {
        transform.position = GameObject.Find("Player").transform.position;

    }
    public void setMask(float time)
    {
        this.gameObject.SetActive(true);

        StartCoroutine(DelayPhaseProgress(time));
    }
    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        this.gameObject.SetActive(false);
    }
}
