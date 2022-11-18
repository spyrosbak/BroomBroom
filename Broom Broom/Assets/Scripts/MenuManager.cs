using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject objectInScene;

    public void Play()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    private void Update()
    {
        if(settingsPanel.activeSelf || gameplayPanel.activeSelf)
        {
            objectInScene.GetComponent<Animator>().enabled = false;
        }
        else
        {
            objectInScene.GetComponent<Animator>().enabled = true;
        }
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void ShowHighscores()
    {
        gameplayPanel.SetActive(true);
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
