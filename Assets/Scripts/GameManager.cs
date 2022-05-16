using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    // to protect GameManager
    public static GameManager instance {get; private set;}

    public AudioSource lossSound;
    public string playerName;

    public int characterPlayed;

    public bool isGameActive;

    public int[] bestScore;
    public string[] bestScorePlayerName;


    private void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
        lossSound = GetComponent<AudioSource>();
    }


    // save system
    [System.Serializable]
    class SaveData
    {
        public string[] bestScorePlayerName = new string[3];
        public int[] bestScore = new int[3];
    }

        public void SaveHighScore()
    {
        SaveData data = new SaveData();
        for (int i = 0; i < bestScore.Length; i++)
        {
                data.bestScorePlayerName[i] = bestScorePlayerName[i];
                data.bestScore[i] = bestScore[i];
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            for (int i = 0; i < bestScore.Length; i++)
            {
                bestScorePlayerName[i] = data.bestScorePlayerName[i];
                bestScore[i] = data.bestScore[i];
            }

        }
    }

    public void PlayLossSound()
    {
        lossSound.Play();
    }

}
