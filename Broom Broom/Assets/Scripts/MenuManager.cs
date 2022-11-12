using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject HighScoresPanel;
    public void Play()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void ShowSettings()
    {
        SettingsPanel.SetActive(true);
    }

    public void ShowHighscores()
    {
        HighScoresPanel.SetActive(true);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif

        #if PLATFORM_STANDALONE_WIN
            Application.Quit();
        #endif
    }
}
