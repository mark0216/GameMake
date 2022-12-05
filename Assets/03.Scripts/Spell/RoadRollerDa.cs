using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRollerDa : BaseSpellTrigger
{
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private float dropSpeed;

    private void Start()
    {
        transform.position += new Vector3(0, 10, 0);
    }
    private void Update()
    {
        transform.position -= new Vector3(0, dropSpeed * Time.deltaTime, 0);
    }
    protected override void HitPlayer()
    {
        Instantiate(videoPlayer);
    }
}
