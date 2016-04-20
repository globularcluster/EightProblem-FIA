using UnityEngine;
using System.Collections;
using System;

public class ShowSolution : MonoBehaviour
{

	private ArrayList slots;
	private ArrayList pieces;

	public Transform Pecas;


	// Use this for initialization
	void Start ()
	{
		slots = new ArrayList (9);
		pieces = new ArrayList (9);

		foreach (Transform obj in transform.GetComponentsInChildren<Transform> ()) {
			if (obj.tag == "slot")
				slots.Add (obj);
			else
				continue;	
		}

		foreach (Transform peca in Pecas.transform.GetComponentsInChildren<Transform> ()) {
			if (peca.tag == "piece")
				pieces.Add (peca);
			
		}

		ArrayList teste = new ArrayList ();
		teste.Add (1);
		teste.Add (2);
		teste.Add (3);
		teste.Add (4);
		teste.Add (0);
		teste.Add (6);
		teste.Add (7);
		teste.Add (8);
		teste.Add (5);

		SetSlotSolution (teste);

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	private void SetSlotSolution (ArrayList arr)
	{
		int i = 0;
		foreach (Transform slot in slots) {

			int index = (int)arr [i++];
			Debug.Log (index);
			if (index == 0)
				continue;
			

			Transform tr = (Transform)pieces [index - 1];
			tr.position = slot.position;
			tr.SetParent (slot);
		}
	}
}