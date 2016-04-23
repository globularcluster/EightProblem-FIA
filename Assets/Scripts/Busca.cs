using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Busca : MonoBehaviour
{

	public Transform pecasIni;
	public Transform pecasFin;
	public Transform slotsIni;
	public Transform slotsFin;
	public GameObject warnPanel;

	public void ProfunClicked ()
	{
		// Testes necessários antes de efetuar a busca: todas peças estão sendo utilizadas, 
		// se é possivel encontrar uma soução
		if (!testes ())
			return;

		ArrayList estadoInicial = getPosições (slotsIni);
		ArrayList estadoMeta = getPosições (slotsFin);

		SceneManager.LoadScene ("Busca");

	}

	public void LarguraClicked ()
	{
		if (!testes ())
			return;

		ArrayList estadoInicial = getPosições (slotsIni);
		ArrayList estadoMeta = getPosições (slotsFin);

		SceneManager.LoadScene ("Busca");

	}

	private bool testes ()
	{
		// percorre pilha de peças do Estado Inicial, se encontrar alguma, warning é exibido
		foreach (Transform slotTransform in pecasIni.GetComponentsInChildren<Transform>()) {
			if (slotTransform.GetComponent<DragMe> ()) {
				warnPanel.SetActive (true);
				return false;
			}
		}

		// percorre pilha d peças do Estado Final, se houver peça na pilha ainda, warning é exibido
		//		foreach (Transform slotTransform in pecasFin.GetComponentsInChildren<Transform>()) {
		//			if (slotTransform.GetComponent<DragMe> ()) {
		//				warnPanel.SetActive (true);
		//				return false;
		//			}
		//		}

		return true;
	}

	private ArrayList getPosições (Transform slots)
	{

		ArrayList posic = new ArrayList (9);

		// coloca posições iniciais e coloca em um ArrayList
		foreach (Transform slotTransform in slotsIni.GetComponentsInChildren<Transform>()) {
			if (slotTransform.tag == "slot") {
				DragMe dm = slotTransform.GetComponentInChildren<DragMe> ();

				if (dm)
					posic.Add (dm.value);
				else
					posic.Add (0);
			} else
				continue;
		}

		foreach (int i in posic) {
			Debug.Log (i);
		}

		return posic;
		
	}
		
}
