using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject GameOverPanel;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject GetReady;

    public static int gameScore;
    public GameObject score;

    private void Start()
    {
        score.SetActive(false);
        GetReady.SetActive(true);
        GameOverPanel.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (playerMovement.isDead)
        {
            score.SetActive(false);
            gameScore = score.GetComponent<ScoreController>().GetScore();
            GameOverPanel.SetActive(true);
        }

        if (playerMovement.isStart)
        {
            score.SetActive(true);
            GetReady.SetActive(false);
        }
    }
}
