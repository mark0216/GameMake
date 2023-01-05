using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall_Control : BaseSpellTrigger
{
    [SerializeField] private GameObject exp ;

    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float effectDuration = 0.3f;
    public Animator Anim_player;


    void Start()
    {
        
    }


    void Update()
    {
        checkLrSide();
        checkPosOut();
        if (Anim_player.GetCurrentAnimatorStateInfo(0).IsName("end"))
        {
            Destroy(this.gameObject);

        }

    }
    protected override void HitPlayer()
    {
        //   GameObject.Find("Player").GetComponent<CommonMove>().AssignForce();

        //StartCoroutine(DelayPhaseProgress(effectDuration));
        FindObjectOfType<PlayerMove>().SetAirSpeed(0.3f, 20f, 10f);
        FindObjectOfType<PlayerMove>().AssignForce(movementSpeed * 1000,1000f);
        exp.SetActive(true);
        movementSpeed = 0;
        GetComponent<SpriteRenderer>().enabled = false;
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
