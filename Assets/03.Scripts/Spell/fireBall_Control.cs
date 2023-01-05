using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall_Control : BaseSpellTrigger
{
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float effectDuration = 3f;
    [SerializeField] private float moveSpeed = 3f;

    
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
     //   GameObject.Find("Player").GetComponent<CommonMove>().AssignForce();
        
        StartCoroutine(DelayPhaseProgress(effectDuration));

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
