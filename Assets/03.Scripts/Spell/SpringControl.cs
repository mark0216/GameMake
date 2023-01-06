using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringControl : BaseSpellTrigger
{
    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audioSource;
    protected override void HitPlayer()
    {
        audioSource.Play(0);
        anim.SetTrigger("do");
        FindObjectOfType<PlayerMove>().AssignForce(0, movementSpeed, movementSpeed);
    }
}
