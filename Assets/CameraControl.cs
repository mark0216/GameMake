using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private int currentlevel;

    [Header("Setting")]
    [SerializeField] private int levelHight;
    [SerializeField] private int hightCondiction;
    void Update()
    {
        if (playerPos.position.y > currentlevel * levelHight + hightCondiction)
        {
            currentlevel++;
            transform.position = new Vector3(transform.position.x, currentlevel * levelHight, transform.position.z);
        }
        else if (playerPos.position.y < (currentlevel - 1) * levelHight + hightCondiction)
        {
            if (currentlevel != 0)
            {
                currentlevel--;
                transform.position = new Vector3(transform.position.x, currentlevel * levelHight, transform.position.z);
            }
        }
    }
}
