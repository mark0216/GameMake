using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring_Control : BaseSpellTrigger
{
    [SerializeField] private float movementSpeed = 1000f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.transform.parent.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void HitPlayer()
    {
        //   GameObject.Find("Player").GetComponent<CommonMove>().AssignForce();
        anim.SetTrigger("do");
        //StartCoroutine(DelayPhaseProgress(effectDuration));
        FindObjectOfType<PlayerMove>().SetAirSpeed(0.3f, 18f, 13f);
        FindObjectOfType<PlayerMove>().AssignForce(0, movementSpeed);
    }
}
