using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public int highScore;
    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text highScoreText;

    void Start()
    {
        currentScore = 0;
        highScore = PlayerPrefs.GetInt("Machine1HS", 0);
    }

    // Update is called once per frame
    void Update()
    {
        // currentScoreText.text = currentScore.ToString();
        // highScoreText.text = highScore.ToString();
    }
}
