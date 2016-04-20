using UnityEngine;
using System.Collections;
using UnityEngine.EventSystem;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OrdemEstadoInicial : MonoBehaviour, IHasChanged
{

	[SerializeField]
	Transform slots;

	[SerializeField]
	Text tex;

	private ArrayList ordArr = new ArrayList (9);

	public void HasChanged ()
	{
		// COLOCA PEÇAS EM UM ARRAYLIST NA ORDEM QUE ESTÁ NO TABULEIRO
		ordArr.Clear ();
		foreach (Transform slotTransform in slots.GetComponentsInChildren<Transform>()) {
			DragMe dm = slotTransform.GetComponent<DragMe> ();
			if (dm)
				ordArr.Add (dm.value);
			
		}

		#region DEBUG
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();
		builder.Append (" - ");

		foreach (int i in ordArr) {
			builder.Append (i.ToString ());
			builder.Append (" - ");
		}
 
		tex.text = builder.ToString ();
		#endregion
	}

}

namespace UnityEngine.EventSystem
{

	public interface IHasChanged : IEventSystemHandler
	{
		void HasChanged ();
	}

}
