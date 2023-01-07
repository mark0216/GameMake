using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoLifeTime : SpellLifeTime
{
    private AudioSource bgm;
    void Start()
    {
        bgm = GameObject.FindGameObjectsWithTag("Bgm")[0].GetComponent<AudioSource>();
        StartCoroutine(MuteBgm(LifeTime));
        bgm.volume = 0;
    }


    IEnumerator MuteBgm(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        bgm.volume = 1;
        Destroy(this.gameObject);
    }
}
