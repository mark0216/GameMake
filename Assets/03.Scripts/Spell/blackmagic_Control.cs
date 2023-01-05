using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackmagic_Control : BaseSpellTrigger
{
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float effectDuration = 3;
    [SerializeField] private GameObject PanelMask;

    void Start()
    {

    }
    void Update()
    {
        checkLrSide();
        checkPosOut();

    }
    protected override void HitPlayer()
    {
        PanelMask.SetActive(true);
        GameObject.Find("PanelMask").GetComponent<PanelMask>().setMask(5f);
        Destroy(this.gameObject);

    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);

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
