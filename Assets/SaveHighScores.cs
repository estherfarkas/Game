using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveHighScores : MonoBehaviour
{

    public const int NUM_HIGH_SCORES = 5;
    public const string SCORE_KEY = "HScore";
    [SerializeField] int playerScore;

    [SerializeField] Text[] scoreTexts;

    // Start is called before the first frame update
    void Start()
    {
       playerScore = PersistantData.Instance.GetScore();

       SaveScore();

    }

    public void SaveScore()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            string currentScoreKey = SCORE_KEY + i;

            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                if (playerScore > currentScore)
                {
                    int tempScore = currentScore;

                    PlayerPrefs.SetInt(currentScoreKey, playerScore);

                    playerScore = tempScore;
                }
            }

            else
            {
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                return;
            }
        }
    }

    public void ViewHighScores()
    {

    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            scoreTexts[i].text = PlayerPrefs.GetInt(SCORE_KEY + i).ToString();
        }
        
    }


}
