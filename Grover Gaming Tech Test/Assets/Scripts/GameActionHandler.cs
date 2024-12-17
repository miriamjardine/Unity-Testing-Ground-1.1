using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameAction gameActionObj;
    public UnityEvent onRaiseEvent;

    private void Start()
    {
        gameActionObj.raise += Raise;
    }

    private void Raise()
    {
        onRaiseEvent.Invoke();
    }

}
