using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int playerScore = 0;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text tractorText;
    [SerializeField] private TMP_Text harvesterText;
    [SerializeField] private TMP_Text notification;

    private void Start()
    {
        notification.SetText(" ");
    }

    public void AddToScore(int amount)
    {
        playerScore += amount;
        scoreText.SetText("Score: " + playerScore);
    }

    public void UpdateTractorText(string text)
    {
        tractorText.SetText(text);
    }

    public void UpdateHarvestorText(string text)
    {
        harvesterText.SetText(text);
    }

    public void MakeNotification(string text)
    {
        notification.SetText(text);
    }
}
