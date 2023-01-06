  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonState : MonoBehaviour
{
    public bool Dazzing;

    private void Start()
    {
        Dazzing = false;
    }

    public void AssignDazz(float MaintainLength, bool isFreeze)
    {
        StartCoroutine(Dazz(MaintainLength, isFreeze));
    }

    IEnumerator Dazz(float MaintainLength,bool isFreeze)
    {
        Dazzing = true;
        if (isFreeze)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        }
        yield return new WaitForSecondsRealtime(MaintainLength);
        Dazzing = false;
        if (isFreeze)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
