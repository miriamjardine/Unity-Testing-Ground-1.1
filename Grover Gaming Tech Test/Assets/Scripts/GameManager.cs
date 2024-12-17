
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public ChestData[] chestDataArray;

    public Button playButton;
    public Button increaseButton, decreaseButton;
    public Text currentBalanceText;
    public Text currentDenominationText;
    public Text lastWinText;

    public Button[] chestButtons;

    private float currentBalance = 10.0f;
    private float lastWin = 0.0f;
    private List<float> predeterminedWins;
    private int chestPickIndex;

    public void Start()
    {
        UpdateUI();
        ResetChests();
        playButton.onClick.AddListener(StartGame);
        increaseButton.onClick.AddListener(IncreaseDenomination);
        decreaseButton.onClick.AddListener(DecreaseDenomination);
    }

    public void UpdateUI()
    {
        currentBalanceText.text = $"${currentBalance:F2}";
        currentDenominationText.text = $"Bet: ${gameData.denominations[gameData.currentDenominationIndex]:F2}";
        lastWinText.text = $"Last Win: ${lastWin:F2}";
        playButton.interactable = currentBalance >= gameData.denominations[gameData.currentDenominationIndex]; 

    }

    public void StartGame()
    {
        if(currentBalance < gameData.denominations[gameData.currentDenominationIndex]) return;

        playButton.interactable = false;
        increaseButton.interactable = false;
        decreaseButton.interactable = false;

        currentBalance -= gameData.denominations[gameData.currentDenominationIndex];
        lastWin = 0;
        chestPickIndex = 0;

        GenerateChestResults();
        ResetChests();
        UpdateUI();

    }

    public void GenerateChestResults()
    {
        predeterminedWins = new List<float>();
        float bet = gameData.denominations[gameData.currentDenominationIndex];
        float totalWin = SelectMultiplier() * bet;

        int numChestsWithWins = Random.Range(1,9);
        float remainingWin = totalWin;

        for(int i = 0; i < numChestsWithWins; i++)
        {
            float win = Mathf.Min(remainingWin, Random.Range(0.05f, remainingWin)); 
            predeterminedWins.Add(Mathf.Round(win * 20) / 20.0f);
            remainingWin -= win;

        }

        float SelectMultiplier()
        {
            float roll = Random.value;

            if(roll < 0.50f) return 0;
            if(roll < 0.80f) return gameData.lowMultipliers[Random.Range(0, gameData.lowMultipliers.Length)]; 
            if(roll < 0.95f) return gameData.midMultipliers[Random.Range(0, gameData.midMultipliers.Length)]; 
            return gameData.highMultipliers[Random.Range(0, gameData.highMultipliers.Length)];
        }
    }

        public void OnChestSelected(int chestIndex)
        {
            if(chestPickIndex >= predeterminedWins.Count) return;

            float win = predeterminedWins[chestPickIndex];
            chestPickIndex++;

            chestButtons[chestIndex].interactable = false;
            chestButtons[chestIndex].GetComponentInChildren<Text>().text = win > 0 ? $"${win:F2}" : "Pooper";

            if(win == 0) EndRound();
            else
            {
                lastWin += win;
                UpdateUI();
            }

        }

        void EndRound()
        {
            currentBalance += lastWin;
            UpdateUI();

            playButton.interactable = true;
            increaseButton.interactable = true;
            decreaseButton.interactable = true;
        }

        void ResetChests()
        {
            foreach(var button in chestButtons)
            {
                button.interactable = true;
                button.GetComponentInChildren<Text>().text = "?";
            }
        }

        void IncreaseDenomination()
        {
            gameData.currentDenominationIndex = Mathf.Min(gameData.currentDenominationIndex + 1, gameData.denominations.Length -1);
            UpdateUI();
        }

        void DecreaseDenomination()
        {
            gameData.currentDenominationIndex = Mathf.Max(gameData.currentDenominationIndex - 1, 0);
            UpdateUI();
        }
    }



