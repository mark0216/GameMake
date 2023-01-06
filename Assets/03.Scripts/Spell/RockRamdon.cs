using UnityEngine;

public class RockRamdon : MonoBehaviour
{
    [SerializeField] private GameObject Rock;
    [SerializeField] private GameObject bigRock;
    void Start()
    {
        if (Random.Range(0.0f, 100.0f) > 20f)
            Rock.SetActive(true);
        else
            bigRock.SetActive(true);
    }
}
