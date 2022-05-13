using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;
    public TextMeshProUGUI description;

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter <0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void GameScene()
    {   
        switch (selectedCharacter)
        {
            case 0:
                GameManager.instance.characterPlayed = 0;
                break;
            case 1:
                GameManager.instance.characterPlayed = 1;
                break;
            case 2:
                GameManager.instance.characterPlayed = 2;
                break;
            default:
                GameManager.instance.characterPlayed = 0;
                break;
        }
        
        SceneManager.LoadScene(2);
    }
}
