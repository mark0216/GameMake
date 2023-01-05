using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piston : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float AnimationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AnimationSpeed < 0)
        {
            AnimationSpeed = 0;
        }
        anim.speed = AnimationSpeed;
    }

    private void PistonTrigger()
    {
        anim.SetTrigger("do");
    }
}
