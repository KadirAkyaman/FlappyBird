using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalController : MonoBehaviour
{
    [SerializeField] List<Sprite> medals;
    [SerializeField] ScoreController scoreController;
    Image medalImage;

    int gameScore;

    void Start()
    {
        medalImage = GetComponent<Image>();
    }

    void Update()
    {
        gameScore = scoreController.score;
        Debug.Log(gameScore);

        
        if (gameScore >= 0 && gameScore <= 5)
        {
            medalImage.sprite = medals[0];
        }
        else if (gameScore > 5 && gameScore <= 19)
        {
            medalImage.sprite = medals[1];
        }
        else if (gameScore >= 20 && gameScore <= 29)
        {
            medalImage.sprite = medals[2];
        }
        else if (gameScore >= 30)
        {
            medalImage.sprite = medals[3];
        }
    }
}
