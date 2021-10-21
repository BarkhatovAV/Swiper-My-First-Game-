using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreRecordView : MonoBehaviour
{
    [SerializeField] private Record _scoreRecord;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _scoreRecord.ScoreRecordChanged += OnScoreRecordChanged;
    }

    private void OnDesable()
    {
        _scoreRecord.ScoreRecordChanged += OnScoreRecordChanged;
    }

    private void OnScoreRecordChanged(int scoreRecord)
    {
        _text.text = "Record  " + scoreRecord;
    }
}
