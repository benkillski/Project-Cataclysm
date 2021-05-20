using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    int score;
    [SerializeField] TextMeshProUGUI scoreDisplayText;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreDisplayText.text = "SCORE: " + score;
    }
}
