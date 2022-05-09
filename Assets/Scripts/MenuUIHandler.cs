using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    public GameObject inputNameField;

    public void StartGame()
    {
        GameManager.instance.playerName = inputNameField.GetComponent<Text>().text;
        SceneManager.LoadScene(1);
    }

    public void TitleScene()
    {
        SceneManager.LoadScene(0);
    }

        public void GameScene()
    {
        SceneManager.LoadScene(2);
    }

        public void HowToPlayScene()
    {
        SceneManager.LoadScene(3);
    }

        public void HighScoreScene()
    {
        SceneManager.LoadScene(4);
    }

        public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
