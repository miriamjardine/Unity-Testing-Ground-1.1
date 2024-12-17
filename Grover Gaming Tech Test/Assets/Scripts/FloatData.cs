using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]

public class FloatData : ScriptableObject

{
    public float value;
    public UnityEvent disableEvent;

    public void UpdateValue(float num)
    {
        value += num;
    }

    public void CompareValue(FloatData obj)
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

    public void ReplaceValue(float num)
    {
        value = num;
    }

    public void ReplaceValue(FloatData obj)
    {
        value = obj.value;
    }

}
