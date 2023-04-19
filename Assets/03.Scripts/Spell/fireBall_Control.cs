using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall_Control : BaseSpellTrigger
{
    [SerializeField] private GameObject exp ;

    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float effectDuration = 0.3f;
    public Animator Anim_player;
    public Vector2 expForce;

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
        if (Anim_player.GetCurrentAnimatorStateInfo(0).IsName("end"))
        {
            Destroy(this.gameObject);
        }
    }

    protected override void HitPlayer()
    {
        float originVerticalSpeed = (float)(player.GetComponent<CommonMove>()?.VerticalSpeed);
        Vector2 dir = player.transform.position - transform.position;
        dir.Normalize();
        player.GetComponent<CommonMove>()?.AssignForce(Mathf.Abs(movementSpeed) * dir.x, originVerticalSpeed + Mathf.Abs(movementSpeed) * dir.y, 13f);

        player.GetComponent<PlayerMoveV2>()?.Knockback(dir * expForce);
        exp.SetActive(true);
        movementSpeed = 0;
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
