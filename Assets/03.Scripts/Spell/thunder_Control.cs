using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunder_Control : BaseSpellTrigger
{
    [SerializeField] private float effectDuration = 5;
    [SerializeField] private Animator Anim_player;
    void Start()
    {
        Anim_player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim_player.GetCurrentAnimatorStateInfo(0).IsName("end"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject);
        }
    }
    protected override void HitPlayer()
    {
        player.GetComponent<CommonState>().AssignDazz(effectDuration, true);
       // FindObjectOfType<PlayerMove>().SetAirSpeed(effectDuration, 8f,10f);
        print(gameObject.name + " hit");
    }

}
