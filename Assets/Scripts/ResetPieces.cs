using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetPieces : MonoBehaviour
{

	public Transform slots;
	public Transform pieces;
    public Busca busca;
    public NextState nextState;

    public Text statusDisplay;

    public void Reset ()
	{
		
		foreach (Transform slotTransform in slots.GetComponentsInChildren<Transform>()) {
			Transform tr = slotTransform.GetComponentInChildren<Transform> ();

			if (tr.tag == "pieceIni") {
				tr.SetParent (pieces);
				tr.position = pieces.position;
			}
		}

        resetBusca();

	}

    public void resetBusca()
    {
        busca.aberto.Clear();
        busca.fechado.Clear();
        busca.solucao.Clear();
        busca.arvore.Clear();
        busca.achouMeta = false;
        busca.testados = 0;
        busca.profMax = GameObject.Find("Entrada").GetComponent<Entrada>().prof;
        busca._inversoes = 0;
        busca._largAux = 0;
        busca.nodoCode = 0;
        nextState.primeira = true;
        nextState.restaSolucoes = true;

        statusDisplay.text = " ";
    }
}
