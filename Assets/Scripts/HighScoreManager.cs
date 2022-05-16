using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI[] playerNames;
    public TextMeshProUGUI[] highScores;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerNames.Length; i++)
        {
            playerNames[i].text = GameManager.instance.bestScorePlayerName[i];
            highScores[i].text = "" + GameManager.instance.bestScore[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
