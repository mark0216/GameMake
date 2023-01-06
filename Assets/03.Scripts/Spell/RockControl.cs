using UnityEngine;

public class RockControl : BaseSpellTrigger
{
    [SerializeField] private float effectDuration = 2f;
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private GameObject audioSource;

    void Start()
    {
        transform.position += new Vector3(0, 25, 0);
        player = GameObject.FindGameObjectsWithTag("Player")[0];

    }
    void Update()
    {
        checkPosOut();
    }
    protected override void HitPlayer()
    {
        audioSource.SetActive(true);

        player.GetComponent<CommonState>().AssignDazz(effectDuration, false);
    }
    private void checkPosOut()
    {
        if (transform.position.y < GameObject.Find("bottom").transform.position.y)
            Destroy(gameObject.transform.parent.gameObject);
        else
            transform.position = transform.position + new Vector3( 0, -movementSpeed * Time.deltaTime, 0);
    }
}
