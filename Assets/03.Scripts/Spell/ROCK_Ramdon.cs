using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROCK_Ramdon : MonoBehaviour
{
    [SerializeField] private GameObject Rock;
    [SerializeField] private GameObject bigRock;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0.0f, 100.0f) > 20f)
        {
            Rock.SetActive(true);
        }
        else
        {
            bigRock.SetActive(true);
        }
    }
}
