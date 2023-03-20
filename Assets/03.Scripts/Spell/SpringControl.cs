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
        player.GetComponent<PlayerMove>()?.AssignForce(0, movementSpeed, movementSpeed);
        player.GetComponent<PlayerMoveV2>()?.Knockback(Vector2.up * movementSpeed);
    }
}
