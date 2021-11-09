using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    private void Start()
    {
        GetComponent<ScoreCounter>().UpdateScore += UpdateText;
    }

    public void UpdateText(int value)
    {
        _scoreText.SetText(value.ToString());
    }
}
