using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring_Control : BaseSpellTrigger
{
    [SerializeField] private float movementSpeed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void HitPlayer()
    {
        //   GameObject.Find("Player").GetComponent<CommonMove>().AssignForce();

        //StartCoroutine(DelayPhaseProgress(effectDuration));
        FindObjectOfType<PlayerMove>().SetAirSpeed(0.3f, 20f, 10f);
        FindObjectOfType<PlayerMove>().AssignForce(0, movementSpeed);
    }
}
