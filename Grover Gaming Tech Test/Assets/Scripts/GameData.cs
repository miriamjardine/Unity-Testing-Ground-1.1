
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "PickBonus/GameData")]

public class GameData : ScriptableObject
{
  public float[] denominations = { 0.25f, 0.50f, 1.0f, 5.0f };
  public int currentDenominationIndex = 0;

  public float[] lowMultipliers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
  public float[] midMultipliers = { 12, 16, 24, 32, 48, 64 };  
  public float[] highMultipliers = { 100, 200, 300, 400, 500 };
}
