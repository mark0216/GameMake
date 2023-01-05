using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piston : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float delaySecUp = 1f;
    [SerializeField] private float delaySecDown = 1f;

    private bool isAnimation = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAnimation)
        {
            StartCoroutine(DelayPhaseProgress(delaySecUp, delaySecDown));

        }
    }
    IEnumerator DelayPhaseProgress(float delaySec01, float delaySec02)
    {
        isAnimation = true;
        PistonTrigger();
        yield return new WaitForSeconds(delaySec01);
        PistonTrigger();
        yield return new WaitForSeconds(delaySec02);
        isAnimation = false;

    }
    private void PistonTrigger()
    {
        anim.SetTrigger("do");
    }
}
