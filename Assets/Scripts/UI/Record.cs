using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Record : MonoBehaviour
{
    [SerializeField] private Score _score;

    private const string _record = "Record";
    private int _scoreRecord;

    public int ScoreRecord => _scoreRecord;

    public event UnityAction<int> ScoreRecordChanged;

    private void OnEnable()
    {
        _score.ScoreChanged += OnScoreChanged;
    }


    private void OnDisable()
    {
        _score.ScoreChanged -= OnScoreChanged;
    }

    private void Start()
    {
        _scoreRecord = GetRecord();
        ScoreRecordChanged?.Invoke(_scoreRecord);
    }
    private void OnScoreChanged(int score)
    {
        if(score > _scoreRecord)
        {
            _scoreRecord = score;
            SetRecord(_scoreRecord);
            ScoreRecordChanged?.Invoke(_scoreRecord);    
        }
    }

    private void SetRecord(int scoreRecord)
    {
         PlayerPrefs.SetInt(_record, scoreRecord);
    }

    private int GetRecord()
    {
        return PlayerPrefs.GetInt(_record);
    }
}
