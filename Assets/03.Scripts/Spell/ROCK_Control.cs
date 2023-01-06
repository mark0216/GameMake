using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROCK_Control : BaseSpellTrigger
{
    [SerializeField] private float effectDuration = 2f;
    [SerializeField] private float movementSpeed = 3f;
    void Start()
    {
        transform.position = new Vector3(transform.position.x, GameObject.Find("right").transform.position.y,  transform.position.z);
    }
    void Update()
    {
        checkPosOut();
    }
    protected override void HitPlayer()
    {
        GameObject.Find("Player").GetComponent<CommonState>().AssignDazz(effectDuration, false);
        Destroy(gameObject.transform.parent.gameObject);
    }
    private void checkPosOut()
    {
        if (transform.position.y < GameObject.Find("bottom").transform.position.y)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            transform.position = transform.position + new Vector3( 0, -movementSpeed * Time.deltaTime, 0);
        }
    }
}
