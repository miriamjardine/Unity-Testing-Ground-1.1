using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]

public class IntData : ScriptableObject

{
    public int value;
    public UnityEvent disableEvent;

    public void UpdateValue(int num)
    {
        value += num;
    }

    public void CompareValue(IntData obj)
    {
        if(value >= obj.value)
        {
            return;
        }
        else
        {
            value = obj.value;
        }
    }

    public void ReplaceValue(int num)
    {
        value = num;
    }

    public void ReplaceValue(IntData obj)
    {
        value = obj.value;
    }

}
