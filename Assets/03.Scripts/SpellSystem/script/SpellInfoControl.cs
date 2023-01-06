using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellInfoControl : MonoBehaviour
{
    //[SerializeField] private SpellManager spellManager;
    public SpellData _data;

    [Header("UI")]
    [SerializeField] private Text _cost;
    [SerializeField] private Image _spellIcon;
    [SerializeField] private Image _typeIcon;

    [Header("Setting")]
    [SerializeField] private List<Sprite> spellIcons;
    public Button _button;

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
        _cost.text = _data.s_data.cost.ToString();
        _spellIcon.sprite = _data.s_data.icon;
        _typeIcon.sprite = spellIcons[(int)_data.s_data.spellType];
        //   _spellIcon.sprite = _data.s_data.icon;
    }
}
