using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HeroModel : CharacterModel
{
    [SerializeField] Image _hpImage;

    private void Update()
    {
        _hpImage.fillAmount = _currentHp / _maxHp;
    }
}
