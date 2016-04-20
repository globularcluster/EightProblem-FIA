using UnityEngine;
using System.Collections;

public class ResetPieces : MonoBehaviour
{

	public Transform slots;
	public Transform pieces;

	public void Reset ()
	{
		
		foreach (Transform slotTransform in slots.GetComponentsInChildren<Transform>()) {
			Transform tr = slotTransform.GetComponentInChildren<Transform> ();

			if (tr.tag == "pieceIni") {
				tr.SetParent (pieces);
				tr.position = pieces.position;
			}
		}

	}
}
