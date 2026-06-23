using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject ScoreText;
    public GameObject TimeText;

    private float CurrentTime = 0.0f;
    private float ChangeTime = 1.0f;

    private int Score = 0;

    void Awake()
    {
        // 이미 GameManager가 존재하면 새로 생긴 것은 삭제
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // 현재 GameManager를 Instance로 등록
        Instance = this;
    }

    void Start()
    {
        SetScoreText();
    }

    void Update()
    {
        CurrentTime += Time.deltaTime;

        if (CurrentTime >= ChangeTime)
        {
            SetTimeText();
            ChangeTime += 1.0f;
        }
    }

    public void AddScore(int score)
    {
        Score += score;

        SetScoreText();

    }

    private void SetScoreText()
    {
        if (ScoreText != null)
        {
            Text scoreText = ScoreText.GetComponent<Text>();

            if (scoreText != null)
            {
                scoreText.text = "Score : " + Score;
            }
        }
    }

    private void SetTimeText()
    {
        if (TimeText != null)
        {
            Text TimeTexts = TimeText.GetComponent<Text>();

            if (TimeTexts != null)
            {
                TimeTexts.text = "Time : " + (int)ChangeTime;
            }
        }
    }
}