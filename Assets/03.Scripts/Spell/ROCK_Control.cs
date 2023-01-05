using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROCK_Control : BaseSpellTrigger
{
    [SerializeField] private float effectDuration = 2f;
    [SerializeField] private float movementSpeed = 3f;


    // Start is called before the first frame update
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

        FindObjectOfType<CommonState>().Dazzing = true;
       // GameObject.Find("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        StartCoroutine(DelayPhaseProgress(effectDuration));
    }

    IEnumerator DelayPhaseProgress(float delaySec)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(delaySec);
        FindObjectOfType<CommonState>().Dazzing = false;
        //GameObject.Find("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(effectDuration);

        Destroy(gameObject.transform.parent.gameObject);
    }

    private void checkPosOut()
    {
        if (transform.position.y < GameObject.Find("bottom").transform.position.y)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            StartCoroutine(DelayPhaseProgress(0));
        }
        else
        {
            transform.position = transform.position + new Vector3( 0, -movementSpeed * Time.deltaTime, 0);
        }
    }
}
