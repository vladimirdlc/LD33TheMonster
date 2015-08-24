using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {
    public static ScoreHandler Instance;
    public Text textbox;
    public int currentScore;
    public int targetScore;
    public string format;

    // Use this for initialization
    void Start() {
        Instance = this;
    }

    // Update is called once per frame
    void Update() {
        if (currentScore < targetScore)
        {
            currentScore = 1 + currentScore;
            if (currentScore < targetScore-100)
                currentScore = 10 + currentScore;
            if (currentScore < targetScore - 1000)
                currentScore = 100 + currentScore;
            updateUI();
        }
    }

    void updateUI()
    {
        textbox.text = string.Format(format, currentScore);
    }

    public void addScore(int score)
    {
        targetScore += score;
    }
}
