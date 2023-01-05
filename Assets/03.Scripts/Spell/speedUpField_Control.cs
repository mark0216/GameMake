using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUpField_Control : BaseSpellTrigger
{
    [SerializeField] private float fieldLifetime = 5f;

    [SerializeField] private float effectDuration = 5;
    [SerializeField] private float timer = 0;
    private bool isInside = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayLifetimeProgress(fieldLifetime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void HitPlayer()
    {
        //   FindObjectOfType<PlayerMove>().isChaos = true;
        //speedupOn
        FindObjectOfType<PlayerMove>().SetSpeedPostive(20f);
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
                StartCoroutine(DelayPhaseProgress(effectDuration));
        }
    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(0.1f);
            if (isInside)
            {
                break;
            }
            timer -= 0.1f;

        }
        if (!isInside)
        {
            // FindObjectOfType<PlayerMove>().isChaos = false;
            //speedupOff
            FindObjectOfType<PlayerMove>().SetSpeedPostive(10f);
            print(" off");

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
