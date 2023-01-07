using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rickroller_Control : BaseSpellTrigger
{
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private float dropSpeed;

    private void Start()
    {
        transform.position += new Vector3(0, 25, 0);
    }
    private void Update()
    {
        transform.position -= new Vector3(0, dropSpeed * Time.deltaTime, 0);
        if (transform.position.y < GameObject.Find("bottom").transform.position.y)
            Destroy(this.transform.parent.gameObject);
    }
    protected override void HitPlayer()
    {
        Instantiate(videoPlayer);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
