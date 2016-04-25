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
    public int x;
    public int y;

    public GameObject pecasIni;

	public ArrayList ordArr = new ArrayList (9);
      public int[,] matriz = new int[3, 3]{
            {0,0,0},
            {0,0,0},
            {0,0,0}

        };
	public void HasChanged ()
	{
        Debug.Log("Mudou!");
		// COLOCA PEÇAS EM UM ARRAYLIST NA ORDEM QUE ESTÁ NO TABULEIRO
		ordArr.Clear ();
		foreach (Transform slotTransform in slots.GetComponentsInChildren<Transform>()) {
			DragMe dm = slotTransform.GetComponent<DragMe> ();
			if (dm)
            {
                ordArr.Add(dm.value);
                Debug.Log("adicionou valor" + dm.value);
            }

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
