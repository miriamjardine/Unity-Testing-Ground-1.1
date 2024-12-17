
using UnityEngine;

public class Chest : MonoBehaviour
{
   public GameManager gameManager;
   public int chestIndex;

   public void OnChestClicked()
   {
        gameManager.OnChestSelected(chestIndex);
   }
}
