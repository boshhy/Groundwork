using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Answer
{
    [SerializeField] private string _info;
    public string Info { get { return _info; } }

    [SerializeField] private bool _isCorrect;
    public bool IsCorrect { get { return _isCorrect; } }
}

[CreateAssetMenu(fileName = "New Question", menuName = "Quiz/New Question")]
public class Question : ScriptableObject
{
    public enum AnswerType { Multiple, Single }

    [SerializeField] private string _info = string.Empty;
    public string Info { get { return _info; } }

    [SerializeField] private Answer[] _answers = null;
    public Answer[] Answers { get { return _answers; } }

    // Parameters

    [SerializeField] private bool _usesTimer = false;
    public bool UsesTimer { get { return _usesTimer; } }

    [SerializeField] private int _timer = 0;
    public int Timer { get { return _timer; } }

    [SerializeField] private AnswerType _answerType = AnswerType.Multiple;
    public AnswerType GetAnswerType { get { return _answerType; } }

    [SerializeField] private int _addScore = 10;
    public int AddScore { get { return _addScore; } }

    public List<int> GetCorrectAnswers()
    {
        List<int> CorrectAnswers = new List<int>();
        for (int i = 0; i < Answers.Length; i++)
        {
            if (Answers[i].IsCorrect)
            {
                CorrectAnswers.Add(i);
            }
        }
        return CorrectAnswers;
    }

    public static implicit operator int(Question v)
    {
        throw new NotImplementedException();
    }
}
