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
    private Transform mousePreview;
    //[SerializeField] private GameObject previewObject;

    private MpControl mpControl;

    private List<SpellData> spellList = new List<SpellData>();
    private float sceneEdge = 14.5f;
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

        GameObject empty = new GameObject();
        mousePreview = Instantiate(empty).transform;
        mousePreview.name = "mousePreview";
        Destroy(GameObject.Find("New Game Object"));
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
            if (selectedIndex > -1 && Utility.GetMousePos2D().x < sceneEdge)
            {
                print("cast");
                StartCoroutine(CastSpell());
            }
        }
        //預覽物件移動
        MousePreviewControl();
    }

    public void PressSpellButton(int index)
    {
        print("press button");
        selectedIndex = index;
        CancelSpellSelect();
        Instantiate(infos[index]._data.s_data.previewObj, mousePreview.transform.position, Quaternion.identity).transform.parent = mousePreview;
    }
    private void MousePreviewControl()
    {
        if (mousePreview.childCount > 0)
        {
            mousePreview.transform.position = Utility.GetMousePos2D();

            if (Utility.GetMousePos2D().x < sceneEdge)
                mousePreview.GetChild(0).gameObject.SetActive(true);
            else
                mousePreview.GetChild(0).gameObject.SetActive(false);
        }
    }


    private void CancelSpellSelect()
    {
        selectedIndex = -1;
        if (mousePreview.childCount > 0)
            Destroy(mousePreview.GetChild(0).gameObject);
        //foreach (GameObject i in mousePreview.transform)
        //    Destroy(i);
    }
    IEnumerator CastSpell()
    {
        Vector2 spellPos = Utility.GetMousePos2D();
        Data dataTmp = infos[selectedIndex]._data.s_data;
        mpControl.ReduceMp(dataTmp.cost);

        AddNewSpell(selectedIndex);
        CancelSpellSelect();

        yield return new WaitForSeconds(dataTmp.delayTime);

        Instantiate(dataTmp.spell, spellPos, Quaternion.identity);

    }

    private void CreatInfoSet()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject clone = Instantiate(spellInfoPrefab, spellInfoPrefab.transform.parent);
            clone.name = "Info_" + i.ToString();
            //clone.GetComponent<RectTransform>().position += new Vector3(0, i * -200, 0);
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
