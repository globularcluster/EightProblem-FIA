using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Security.Cryptography;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	private Image slotPanel;
	private Color normalColor;
	public Color highlightColor = Color.yellow;
	public GameObject receiv;

	void Start ()
	{
		slotPanel = GetComponent<Image> ();
		normalColor = slotPanel.color;
	}

	public void OnDrop (PointerEventData data)
	{
		GameObject objDragged = data.pointerDrag;
	
		// Slot recebe peça apenas se for de sua respectiva pilha de peças
		if (objDragged.transform.parent.gameObject != receiv)
			return;

		if (transform.childCount > 0)
			return;
		
		objDragged.transform.SetParent (slotPanel.transform);
		objDragged.transform.position = slotPanel.transform.position;

		ExecuteEvents.ExecuteHierarchy<IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
	}

	public void OnPointerEnter (PointerEventData data)
	{
		GameObject objDragged = data.pointerDrag;
		if (slotPanel == null || objDragged == null || objDragged.transform.parent.gameObject != receiv)
			return;
		
		if (objDragged.GetComponent<DragMe> ())
			slotPanel.color = highlightColor;
               
	}

	public void OnPointerExit (PointerEventData data)
	{
		if (slotPanel == null)
			return;
		
		slotPanel.color = normalColor;
	}
	
}
