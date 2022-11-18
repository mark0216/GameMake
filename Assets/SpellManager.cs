using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject spellInfoPrefab;

    [Header("Data")]
    [SerializeField] private SpellDataBase spellDataBase;
    [SerializeField] private List<SpellInfoControl> infos = new List<SpellInfoControl>();

    [Header("Main")]
    public int selectedIndex;
    [SerializeField] private Transform previewObject;

    private MpControl mpControl;

    private List<SpellData> spellList = new List<SpellData>();
    private int currentListNum = 0;
    void Start()
    {
        mpControl = GetComponent<MpControl>();
        foreach (SpellData tmp in spellDataBase.allSpells)
        {
            spellList.Add(tmp);
            ShuffleSpellList();
        }
        CreatInfoSet();
    }

    void Update()
    {
        CheckInteractable();

        //取消咒語選取
        if (Input.GetMouseButtonDown(1))
        {
            CancelSpellSelect();
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedIndex > -1)
                CastSpell();
        }
        //預覽物件移動
        previewObject.transform.position = Utility.GetMousePos2D();
    }

    public void PressSpellButton(int index)
    {
        selectedIndex = index;
        previewObject.GetComponent<SpriteRenderer>().sprite = infos[index]._data.s_data.previewPic;
    }

    private void CancelSpellSelect()
    {
        selectedIndex = -1;
        previewObject.GetComponent<SpriteRenderer>().sprite = null;
    }
    private void CastSpell()
    {

        selectedIndex = -1;
    }

    private void CreatInfoSet()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject clone = Instantiate(spellInfoPrefab, spellInfoPrefab.transform.parent);
            clone.name = "Info_" + i.ToString();
            clone.GetComponent<RectTransform>().position += new Vector3(0, i * -200, 0);
            infos.Add(clone.GetComponent<SpellInfoControl>());
            int tmp = i;
            clone.GetComponent<SpellInfoControl>()._button.onClick.AddListener(() => PressSpellButton(tmp));

            AddNewSpell(i);
        }
        spellInfoPrefab.SetActive(false);
    }

    private void AddNewSpell(int index)
    {
        infos[index].InputSpellData(spellList[currentListNum]);
        currentListNum++;
        if (currentListNum >= spellList.Count)
        {
            ShuffleSpellList();
            currentListNum = 0;
        }
    }

    private void CheckInteractable()
    {
        foreach (SpellInfoControl i in infos)
        {
            i.MpCheck(mpControl.currentMpValue);
        }
    }

    private void ShuffleSpellList()
    {
        Utility.Shuffle(spellList);
    }
}
