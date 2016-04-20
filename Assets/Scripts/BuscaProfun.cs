using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class BuscaProfun : MonoBehaviour
{

	public Transform pecasIni;
	public Transform pecasFin;
	public Transform slotsIni;
	public GameObject warnPanel;

	private ArrayList ordArr;

	// Use this for initialization
	void Start ()
	{
		ordArr = new ArrayList (9);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ProfunClicked ()
	{
		// percorre pilha de peças do Estado Inicial, se encontrar alguma, warning é exibido
		foreach (Transform slotTransform in pecasIni.GetComponentsInChildren<Transform>()) {
			if (slotTransform.GetComponent<DragMe> ()) {
				warnPanel.SetActive (true);
				return;
			}

		}

		// percorre pilha d peças do Estado Final, se houver peça na pilha ainda, warning é exibido
		foreach (Transform slotTransform in pecasFin.GetComponentsInChildren<Transform>()) {
			if (slotTransform.GetComponent<DragMe> ()) {
				warnPanel.SetActive (true);
				return;
			}
		}


		ordArr.Clear ();
		foreach (Transform slotTransform in slotsIni.GetComponentsInChildren<Transform>()) {
			if (slotTransform.GetComponent<DropMe> ()) {
				DragMe dm = slotTransform.GetComponentInChildren<DragMe> ();

				if (dm)
					ordArr.Add (dm.value);
				else
					ordArr.Add (0);
			} else
				continue;
		}

		foreach (int i in ordArr) {
			Debug.Log (i);
		}

	}
		
}
