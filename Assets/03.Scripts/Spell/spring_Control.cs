using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring_Control : BaseSpellTrigger
{
    [SerializeField] private float movementSpeed = 1000f;
    private Animator anim;

    void Start()
    {
        anim = gameObject.transform.parent.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    protected override void HitPlayer()
    {
        anim.SetTrigger("do");
        FindObjectOfType<PlayerMove>().AssignForce(0, movementSpeed);
    }
}
