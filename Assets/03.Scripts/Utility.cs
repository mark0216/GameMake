using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class Utility
{
    public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }
    public static void CanvasShow(GameObject targetCanvas)
    {
        CanvasGroup CG = targetCanvas.GetComponent<CanvasGroup>();
        CG.interactable = true;
        CG.blocksRaycasts = true;
        CG.alpha = 1;
    }
    public static void CanvasHide(GameObject targetCanvas)
    {
        CanvasGroup CG = targetCanvas.GetComponent<CanvasGroup>();
        CG.interactable = false;
        CG.blocksRaycasts = false;
        CG.alpha = 0;
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = UnityEngine.Random.Range(i, list.Count);
            list.Swap(i, rand);
        }
    }
    public static void Swap<T>(this IList<T> list, int a, int b)
    {
        T tmp = list[a];
        list[a] = list[b];
        list[b] = tmp;
    }

    public static Vector2 GetMousePos2D()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 Worldpos2D = new Vector2(Worldpos.x, Worldpos.y);
        return Worldpos2D;
    }
}
