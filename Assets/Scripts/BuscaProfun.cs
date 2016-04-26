using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuscaProfun : MonoBehaviour
{

	public Transform pecasIni;
	public Transform slotsIni;
	public GameObject warnPanel;
    public int[,] matriz = new int[3, 3];
    public GameObject nextState_btn;
    Entrada entrada;

    public GameObject loading;

    private ArrayList ordArr;

    public Text statusDisplay;
    public Busca _busca;

    public ResetPieces reset;

    void Start ()
	{
        entrada = GameObject.FindGameObjectWithTag("Entrada").GetComponent<Entrada>();
        ordArr = new ArrayList (9);
	}
	
	public void ProfunClicked ()
	{
        reset.resetBusca();
       	// percorre pilha de peças do Estado Inicial, se encontrar alguma, warning é exibido
		foreach (Transform slotTransform in pecasIni.GetComponentsInChildren<Transform>()) {
			if (slotTransform.GetComponent<DragMe> ()) {
				warnPanel.SetActive (true);
				return;
			}

		}

		ordArr.Clear ();
		// coloca posições iniciais e coloca em um ArrayList
		foreach (Transform slotTransform in slotsIni.GetComponentsInChildren<Transform>()) {
			if (slotTransform.tag == "slot") {
				DragMe dm = slotTransform.GetComponentInChildren<DragMe> ();

				if (dm)
                {
                    ordArr.Add(dm.value);
                }
					
				else
					ordArr.Add (0);
			} else
				continue;
		}

            int i, j;
            i = -1;
            j = -1;
            for (int m = 0; m < 9; m++)
            {
                if (m % 3 == 0)
                {
                    i++;

                    j = 0;
                }
                else
                {
                    j++;
                }
                matriz[i, j] = (int)ordArr[m];
                //Debug.Log(matriz[i, j]);
            }

            Debug.Log("Iniciando impressao da matriz...");
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    Debug.Log(matriz[i, j]);
                }
            }

        
        
        for ( i = 0; i < 3; i++)
        {
            for (j = 0; j < 3; j++)
            {
                entrada.inicial[i, j] = matriz[i, j];
            }
        }

        StartCoroutine(efetuaBusca());
        



    }

    IEnumerator efetuaBusca()
    {
        loading.SetActive(true);

        yield return new WaitForSeconds(2f);

        entrada.transfereConteudo();
        entrada.buscaEmProfundidadade();

        loading.SetActive(false);

        statusDisplay.text = "Inversoes: "+_busca._inversoes+"-->"+_busca.soluvel+"\nEstados: \n-Gerados:"+ _busca.arvore.Count + "\n-Testados:"+_busca.testados+"\n-Conjunto Solucao:"+(_busca.solucao.Count-1);

        //ativa o botao de proximo estado
        if (_busca.arvore.Count >1)
        {
            nextState_btn.SetActive(true);
        }
        
    }
		
		
}
