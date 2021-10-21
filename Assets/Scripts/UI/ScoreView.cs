using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _score.ScoreChanged += OnScoreChanged;
    }

    private void OnDesable()
    {
        _score.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _text.text = score.ToString();
    }
}
