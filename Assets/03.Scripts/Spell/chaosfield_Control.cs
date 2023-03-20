using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaosfield_Control : BaseSpellTrigger
{
    [SerializeField] private float fieldLifetime = 5f;
    [SerializeField] private float effectDuration = 5;
    private float timer = 0;
    private bool isInside = false;
    [SerializeField] private GameObject audioSource;

    void Start()
    {
        if (fieldLifetime > 0)
        {
            StartCoroutine(DelayLifetimeProgress(fieldLifetime));
        }
    }
    protected override void HitPlayer()
    {
        audioSource.SetActive(true);
        if (player.GetComponent<PlayerMove>())
            player.GetComponent<PlayerMove>().isChaos = true;
        player.GetComponent<PlayerMoveV2>()?.Chaos(effectDuration);

        isInside = true;
        timer = effectDuration;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInside = false;
            print(gameObject.name + " exit");
            if (timer == effectDuration) 
            StartCoroutine(DelayChaosProgress(effectDuration));
            player.GetComponent<PlayerMoveV2>()?.Chaos(effectDuration);
        }
    }
    IEnumerator DelayChaosProgress(float delaySec)
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(0.1f);
            if (isInside)
            {
                break ;
            }
            timer -= 0.1f;
        }
        if (!isInside)
        {
            if (player.GetComponent<PlayerMove>())
                player.GetComponent<PlayerMove>().isChaos = false;
        }
    }
    IEnumerator DelayLifetimeProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
        }
        Destroy(this.gameObject);
    }
}
