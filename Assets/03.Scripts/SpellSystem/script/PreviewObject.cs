using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    private float delayTime;
    private Sprite pic;
    private GameObject spellPrefab;

    void Update()
    {
        delayTime -= Time.deltaTime;
        if (delayTime <= 0)
        {
            CreateSpellObject();
        }
    }

    public void valueSet(float _delayTime, Sprite _pic, GameObject _spellPrefab)
    {
        delayTime = _delayTime;
        pic = _pic;
        spellPrefab = _spellPrefab;

        GetComponent<SpriteRenderer>().sprite = pic;
    }
    private void CreateSpellObject()
    {
        Instantiate(spellPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
