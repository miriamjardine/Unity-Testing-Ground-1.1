using UnityEngine;
using UnityEngine.Events;
using System.Globalization;
using UnityEngine.UI;

public class ChestClickHandler : MonoBehaviour
{
  public ChestWinData chestWinData;

  public UnityEvent<float> onChestReveal;
  public UnityEvent onAllRevealed;
  private Text label;
  private void Start()
  {
    chestWinData.ResetChestProgress();

    label = GetComponent<Text>();
  }

  public void OnCheckClicked()
  {
    if(!chestWinData.AllChestsRevealed())
    {
        float revealedValue = chestWinData.GetNextChestValue();
        label.text = revealedValue.ToString(CultureInfo.InvariantCulture);
        onChestReveal?.Invoke(revealedValue);
    }

    if(chestWinData.AllChestsRevealed())
    {
        onAllRevealed?.Invoke();

    }
  }
}
