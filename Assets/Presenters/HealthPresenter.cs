using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _healthText;
    private void Start()
    {
        GetComponent<HealthCounter>().OnHealthUpdated += UpdateText;
    }

    public void UpdateText(int value)
    {
        _healthText.SetText(value.ToString());
    }
}
