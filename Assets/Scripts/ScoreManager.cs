using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private float timer;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        //find and show best score with character selected
        if (GameManager.instance.isGameActive)
        { 
            bestScoreText.text = "High Score : " + GameManager.instance.bestScorePlayerName[GameManager.instance.characterPlayed] + " : " + GameManager.instance.bestScore[GameManager.instance.characterPlayed];
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameActive)
        {   
            //calculate and show current score
            timer += Time.deltaTime;
            if (timer> 1f)
            {
                score++;
                timer = 0f;
                if (score > GameManager.instance.bestScore[GameManager.instance.characterPlayed])
                {
                    GameManager.instance.bestScore[GameManager.instance.characterPlayed] = score;
                    GameManager.instance.bestScorePlayerName[GameManager.instance.characterPlayed] = GameManager.instance.playerName;
                    bestScoreText.text = "Best score by " + GameManager.instance.playerName + " : " + score;
                }
            }

            scoreText.text = "Score : " + score;

            //find and show best score with character selected

        }

        
    }
}
