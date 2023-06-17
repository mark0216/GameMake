using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class VersionShow : MonoBehaviour
{
    [SerializeField] Text versionText;
    bool flag = false;
    VersionShow()
    {
        Debug.Log("VersionShow Constructor");
#if UNITY_EDITOR
        EditorApplication.update += UpdateVersion;
#endif
    }

    void UpdateVersion()
    {
        if (versionText)
        {
            if (!flag) 
            {
                Debug.Log("Version text updating...");
                flag = true;
            }
            versionText.text = "Demo V" + Application.version;
        }
    }
}
