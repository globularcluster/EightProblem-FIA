using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	private Image slotPanel;
	private Color normalColor;
	public Color highlightColor = Color.yellow;
	
    void Start()
    {
        slotPanel = GetComponent<Image>();
        normalColor = slotPanel.color;
    }
	
	public void OnDrop (PointerEventData data)
	{
		data.pointerDrag.transform.SetParent(slotPanel.transform);
        data.pointerDrag.transform.position = slotPanel.transform.position;

        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
    }

    public void OnPointerEnter(PointerEventData data)
    {
        GameObject objDragged = data.pointerDrag;
        if (slotPanel == null || objDragged == null)
            return;

        if(objDragged.GetComponent<DragMe>())
            slotPanel.color = highlightColor;
               
    }

	public void OnPointerExit (PointerEventData data)
	{
		if (slotPanel == null)
			return;
		
		slotPanel.color = normalColor;
	}
	
}
