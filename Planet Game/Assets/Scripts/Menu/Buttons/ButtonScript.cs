using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public SoundManager SoundManagerRef;

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManagerRef.PlaySound("Menu Selection");
    }
    public void OnSelect(BaseEventData eventData)
    {

    }
}
