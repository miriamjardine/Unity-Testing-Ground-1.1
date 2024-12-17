using System.Collections.Generic;
using UnityEngine;

public class WinningsBehaviour : MonoBehaviour
{
    public float[] denominations = { 0.25f, 0.50f, 1.00f, 5.00f};
    private float chosenDenomination;
    public float minIncrement = 0.05f;

    private List<int> commonOdds = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    private List<int> medOdds = new List<int> {12, 16, 24, 32, 48, 64};
    private List<int> rareOdds = new List<int> {100, 200, 300, 400, 500};

    private float pooperChance = 0.5f;
    private float commonChance = 0.3f;
    private float medChance = 0.15f;
    private float rareChance = .05f;

    private int selectedMultiplier;
   
    private float totalWinAmt;

    private List<float> chestWinAmts;
    private int pooperChestIndex;

    public ChestWinData chestWinData;

    public void OnPlay()
    {
        // Select a denomination
        chosenDenomination = denominations[Random.Range(0, denominations.Length)];
        Debug.Log($"Selected Denomination: {chosenDenomination}");

        // Get random multiplier
        selectedMultiplier = SelectRandomMultiplier();
        Debug.Log($"Selected Multipier: {selectedMultiplier}");

        // multipy chosen denomination and the selected multiplier to get the total win amt
        totalWinAmt = chosenDenomination * selectedMultiplier;
        Debug.Log($"Total Win Amt: ${totalWinAmt}");

        chestWinData.Distribution();

        //assign random pooper chest
        pooperChestIndex = Random.Range(0, 8);
        Debug.Log($"Pooper Chest Index: {pooperChestIndex}");
    }

    private int SelectRandomMultiplier()
    {
        float roll = Random.value; // value between 0 and 1 like 0.35

        if(roll < pooperChance)
        {
            return 0;
        }

        else if(roll < pooperChance + commonChance)
        {
            return commonOdds[Random.Range(0, commonOdds.Count)];
        }

        else if(roll < pooperChance + commonChance + medChance)
        {
            return medOdds[Random.Range(0, medOdds.Count)];
        }

        else if(roll < pooperChance + commonChance + medChance + rareChance)
        {
            return rareOdds[Random.Range(0, rareOdds.Count)];
        }

        else
        {
            return rareOdds[Random.Range(0, rareOdds.Count)];
        }

    }




    }



