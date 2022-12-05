using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSystem : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject spellInfoPrefab;

    [Header("Data")]
    [SerializeField] private SpellDataBase spellDataBase;
    [SerializeField] private List<SpellInfoControl> infos = new List<SpellInfoControl>();

    [Header("Main")]
    public int selectedIndex;
    [SerializeField] private Transform mousePreview;
    [SerializeField] private GameObject previewObject;

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
            if (selectedIndex > -1 && Utility.GetMousePos2D().x < 5)
                CastSpell();
        }
        //預覽物件移動
        MousePreviewControl();
    }

    public void PressSpellButton(int index)
    {
        selectedIndex = index;
        mousePreview.GetComponent<SpriteRenderer>().sprite = infos[index]._data.s_data.previewPic;
    }
    private void MousePreviewControl()
    {
        mousePreview.transform.position = Utility.GetMousePos2D();
        if (Utility.GetMousePos2D().x < 5)
            mousePreview.GetComponent<SpriteRenderer>().enabled = true;
        else
            mousePreview.GetComponent<SpriteRenderer>().enabled = false;

    }


    private void CancelSpellSelect()
    {
        selectedIndex = -1;
        mousePreview.GetComponent<SpriteRenderer>().sprite = null;
    }
    private void CastSpell()
    {
        mpControl.ReduceMp(infos[selectedIndex]._data.s_data.cost);
        PreviewObject tmp = Instantiate(previewObject, mousePreview.position, Quaternion.identity).GetComponent<PreviewObject>();
        tmp.valueSet(infos[selectedIndex]._data.s_data.delayTime, infos[selectedIndex]._data.s_data.previewPic, infos[selectedIndex]._data.s_data.spell);

        AddNewSpell(selectedIndex);

        CancelSpellSelect();
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
