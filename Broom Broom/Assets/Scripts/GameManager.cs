using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject ExitPanel;
    [SerializeField] private TextMeshProUGUI counerText;
    private PlayerController playerController;
    private float counter;
    private bool timerRunning = false;

    [NonSerialized] public bool gameStart = false;
    [NonSerialized] public bool gamePaused = false;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        counter = 4.0f;

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        instructionsPanel.SetActive(true);
        ExitPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRunning)
        {
            if (counter > 0)
            {
                counter -= Time.deltaTime;
                CountDown(counter);
            }
            else
            {
                counerText.gameObject.SetActive(false);
                gameStart = true;
                timerRunning = false;
            }
        }
    }

    public void StartGame()
    {
        instructionsPanel.SetActive(false);
        timerRunning = true;
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

    private void CountDown(float time)
    {
        counerText.gameObject.SetActive(true);
        float seconds = Mathf.FloorToInt(time % 60);
        counerText.text = seconds.ToString();
    }
}