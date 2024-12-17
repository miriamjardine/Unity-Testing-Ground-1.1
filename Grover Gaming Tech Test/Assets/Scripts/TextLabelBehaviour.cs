using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class TextLabelBehaviour : MonoBehaviour
{
   
   private Text label;
   public UnityEvent startEvent;

   public void Start()
   {
        label = GetComponent<Text>();
        startEvent.Invoke();
   }

   public void UpdateLabel(FloatData obj)
   {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
   }

   public void UpdateLabel(IntData obj)
   {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
   }

   public void UpdateLabel(float value)
   {
       label.text = value.ToString(CultureInfo.InvariantCulture);

   }

}
