using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  
    [Header("UI References")]
    [SerializeField]
    private TMP_Text playerPointsText;
    [SerializeField]
    private TMP_Text roundNumberText;
    [SerializeField]
    private TMP_Text highScoreNumberText;

    [Header("Materials Array")]
    [SerializeField]
    public Material[] materials;

    public bool isPlayerTurn;

    private int highScore = 0;
    private int roundNumber = 1;
    private int playerPoints = 0;
    public int PlayerPoints
    {
        get
        {
            return playerPoints;
        }
        set
        {
            playerPoints = value;
            playerPointsText.text = value.ToString();
        }
    }

    private void Start()
    {
        SetUIOnStart();
        isPlayerTurn = true;
    }

    private void SetUIOnStart()
    { 
        roundNumberText.text = roundNumber.ToString();
        highScoreNumberText.text = highScore.ToString();
        playerPointsText.text = playerPoints.ToString();
    }
    public void UpdateUI()
    {
        highScore += playerPoints;
        playerPoints = 0;
        roundNumber++;
        roundNumberText.text = roundNumber.ToString();
        highScoreNumberText.text = highScore.ToString();
        playerPointsText.text = playerPoints.ToString();
    }
}
