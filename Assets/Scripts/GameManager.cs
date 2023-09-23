using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Question[] _questions = null;
    public Question[] Questions { get { return _questions; } }

    [SerializeField] GameEvents events = null;

    private List<AnswerData> PickedAnswers = new List<AnswerData>();
    private List<int> FinishedQuestions = new List<int>();

    private int currentQuestion = 0;

    void Start()
    {
        LoadQuestions();

        var seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        UnityEngine.Random.InitState(seed);

        Display();
    }

    public void ErasePickedAnswers()
    {
        PickedAnswers = new List<AnswerData>();
    }

    void Display()
    {
        ErasePickedAnswers();

        var question = GetRandomQuestion();

        if (events.UpdateQuestionUI != null)
        {
            events.UpdateQuestionUI(question);
        }
        else
        {
            Debug.LogWarning("Something went wrong while trying to display a new question");
        }
    }

    Question GetRandomQuestion()
    {
        var randomIndex = GetRandomQuestionIndex();
        currentQuestion = randomIndex;

        return Questions[currentQuestion];
    }

    int GetRandomQuestionIndex()
    {
        var random = 0;
        if (FinishedQuestions.Count < Questions.Length)
        {
            do
            {
                random = UnityEngine.Random.Range(0, Questions.Length);
            } while (FinishedQuestions.Contains(random) || currentQuestion == random);
        }

        return random;
    }

    void LoadQuestions()
    {
        Object[] objects = Resources.LoadAll("Comptia/Security+/Questions", typeof(Question));
        _questions = new Question[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            _questions[i] = (Question)objects[i];
        }
    }
}
