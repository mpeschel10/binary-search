using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchScore : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] int bestScore = 3;
    public int score;
    public int Add()
    {
        score++;
        Update();
        return score;
    }

    void Awake()
    {
        Update();
    }

    public void Update()
    {
        scoreText.text = "Actions: " + score + "\nBest: " + bestScore;
    }
}
