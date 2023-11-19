using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI lastScoreText;
    void Start()
    {
        lastScoreText.text = "Last score: " + GameData.LastScore;
    }

    public void EasyGame()
    {
        GameData.InitialDifficulty = DifficultyFactor.EASY;
        SceneManager.LoadScene(1);
    }

    public void MediumGame()
    {
        GameData.InitialDifficulty = DifficultyFactor.MEDIUM;
        SceneManager.LoadScene(1);
    }
    public void HardGame()
    {
        GameData.InitialDifficulty = DifficultyFactor.HARD;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Stop playing the scene in the editor
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
