using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellInfoControl : MonoBehaviour
{
    //[SerializeField] private SpellManager spellManager;
    public SpellData _data;

    [Header("UI")]
    [SerializeField] private Text _name;
    [SerializeField] private Text _cost;
    [SerializeField] private Image _icon;
    public Button _button;

    void Start()
    {

    }

    void Update()
    {

    }

    public void InputSpellData(SpellData input)
    {
        _data = input;
        InfoSet();
    }
    public SpellData GetSpellData()
    {
        return _data;
    }

    public void MpCheck(float mp)
    {
        _button.interactable = mp >= _data.s_data.cost;
    }
    private void InfoSet()
    {
        _name.text = _data.s_data.name;
        _cost.text = _data.s_data.cost.ToString();
        _icon.sprite = _data.s_data.icon;
    }
}
