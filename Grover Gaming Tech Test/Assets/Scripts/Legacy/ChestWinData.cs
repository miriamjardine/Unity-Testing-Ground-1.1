using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu]

public class ChestWinData : ScriptableObject
{

   public int numberOfWinningChests;
    private float minSplit = 0.05f;
    public float totalWinAmt;
    public List<float> chestValues = new List<float>();
    public ChestWinData chestWinData;

    private int currentIndex = 0;
   

    private void OnEnable()
    {
        numberOfWinningChests = Random.Range(0,7);
    }
    public void ResetChestProgress()
    {
        currentIndex = 0;
    }

    public float GetNextChestValue()
    {
        if(currentIndex < chestValues.Count)
        {
            float nextValue = chestValues[currentIndex];
            currentIndex++;
            return nextValue;
            
        }
        else
        {
            Debug.LogWarning("All chests revealed");
            return 0f;
        }

    
    }

    public bool AllChestsRevealed()
    {
        return currentIndex >= chestValues.Count;
        
    }

   public void Distribution()
{
    chestValues.Clear();
    float remainingWin = totalWinAmt;

    for (int i = 0; i < numberOfWinningChests; i++)
    {
       
        float maxPossible = Mathf.Max(remainingWin - (minSplit * (numberOfWinningChests - i - 2)), minSplit);

      
        float chestAmt = Mathf.Floor(Random.Range(minSplit, maxPossible) * 100.0f) / 100.0f;

       
        if (chestAmt < minSplit)
        {
            chestAmt = minSplit; 
        }

        chestValues.Add(chestAmt);
        remainingWin -= chestAmt; 
    }

    
    chestValues[chestValues.Count - 1] += remainingWin;

}


}

