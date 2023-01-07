using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackmagic_Control : BaseSpellTrigger
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float effectDuration;
    [SerializeField] private GameObject PanelMask;

    void Start()
    {
        //player = GameObject.FindGameObjectsWithTag("Player")[0];

        if (movementSpeed >= 0)
        {
            transform.position = new Vector3(GameObject.Find("left").transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(GameObject.Find("right").transform.position.x, transform.position.y, transform.position.z);
        }
    }
    void Update()
    {
        checkLrSide();
        checkPosOut();

    }
    protected override void HitPlayer()
    {
        PanelMask.SetActive(true);
        PanelMask.GetComponent<PanelMask>().setMask(5f);
        StartCoroutine(DelayPhaseProgress(5f));
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;


    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);
        Destroy(this.gameObject);


    }
    private void checkLrSide()
    {
        if (movementSpeed > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void checkPosOut()
    {
        if (transform.position.x < GameObject.Find("left").transform.position.x || transform.position.x > GameObject.Find("right").transform.position.x)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }
    }
}
