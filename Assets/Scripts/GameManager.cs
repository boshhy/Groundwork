using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Question[] _questions = null;
    public Question[] Questions { get { return _questions; } }

    private List<int> FinishedQuestions = new List<int>();

    private int currentQuestion = 0;

    private int score;

    void Display()
    {

    }
}
