using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour
{
   public UnityAction Raise;

   private void Start()
   {
    Raise?.Invoke();
   }
}
