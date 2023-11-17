using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public void EasyGame()
    {
        DifficultySettings.InitialDifficulty = DifficultyFactor.EASY;
        SceneManager.LoadScene(1);
    }

    public void MediumGame()
    {
        DifficultySettings.InitialDifficulty = DifficultyFactor.MEDIUM;
        SceneManager.LoadScene(1);
    }
    public void HardGame()
    {
        DifficultySettings.InitialDifficulty = DifficultyFactor.HARD;
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
