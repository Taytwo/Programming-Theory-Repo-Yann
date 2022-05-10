using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private float timer;

    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameActive)
        {
            timer += Time.deltaTime;
            if (timer> 1f)
            {
                score++;
                timer = 0f;
            }

            scoreText.text = "Score : " + score;
        }

        
    }
}
