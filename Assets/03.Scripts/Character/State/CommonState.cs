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

    public void AssignDazz(float MaintainLength)
    {
        StartCoroutine(Dazz(MaintainLength));
    }

    IEnumerator Dazz(float MaintainLength)
    {
        Dazzing = true;

        yield return new WaitForSecondsRealtime(MaintainLength);

        Dazzing = false;
    }
}
