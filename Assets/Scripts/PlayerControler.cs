using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerControler : MonoBehaviour, IDragHandler, IBeginDragHandler

{
    public Transform player;  
    public ScenaControler ScenaControler;
    
    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
        }
        else
        {
            player.position += new Vector3(0, eventData.delta.y, 0);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
         if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
            {
                ScenaControler.ClickLeftButton();
            } 
            else 
            {
                ScenaControler.ClickRightButton();
            }
           
        }
        else
        {
        }
    }
}

