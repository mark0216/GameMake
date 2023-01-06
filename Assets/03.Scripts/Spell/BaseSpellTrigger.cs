using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpellTrigger : MonoBehaviour
{
    protected GameObject player;
    protected abstract void HitPlayer();

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            HitPlayer();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            HitPlayer();
    }
}
