using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject ExitPanel;
    [SerializeField] private GameObject gameOverPanel;
    private PlayerController playerController;

    [NonSerialized] public bool gameStart = false;
    [NonSerialized] public bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        instructionsPanel.SetActive(true);
        ExitPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void StartGame()
    {
        instructionsPanel.SetActive(false);
        gameStart = true;
    }

    public void PauseGame()
    {
        ExitPanel.SetActive(true);
        gamePaused = true;
    }

    public void ResumeGame()
    {
        ExitPanel.SetActive(false);
        gamePaused = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu_Scene");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        instructionsPanel.SetActive(false);
    }
}