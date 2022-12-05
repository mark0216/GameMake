using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpellTrigger : MonoBehaviour
{
    protected abstract void HitPlayer();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print(gameObject.name + " hit");
            HitPlayer();
        }
    }
}
