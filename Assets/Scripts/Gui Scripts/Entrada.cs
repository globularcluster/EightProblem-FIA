using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Entrada : MonoBehaviour {

    public int[,] inicial = new int[3, 3];    

    public int atual = 0;
    public List<int[,]> solucao = new List<int[,]> { };
    public int prof = 3;
    public Busca busca;


    void Start()
    {
        Busca busca = GameObject.Find("Busca").GetComponent<Busca>();
        Debug.Log(busca);
        
    }
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
            nextState();        
	
	}

    public void nextState()
    {
        if(atual >=0)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameObject.Find("slot_" + solucao[atual][i, j]).GetComponent<Peca>().atualiza(j, i);
                }
            }

            atual--;
        }             
    }

    public void transfereConteudo()
    {
        busca.transfereConteudo();
    }

    public void buscaEmProfundidadade()
    {
        busca.buscaProfundidade(Busca.BUSCA_DEFAULT);

        if (busca.GetComponent<Busca>().achouMeta == false)
        {
            Debug.Log("Não achou resultado.");
        }
        else
        {
            Debug.Log("Achou");

            foreach (Nodo n in busca.GetComponent<Busca>().solucao)
            {
                solucao.Add(n._state);
            }

            atual = solucao.Count - 1;
        }
    }

    public void buscaEmLargura()
    {
        //GameObject busca = GameObject.Find("Busca");
        //busca.GetComponent<Busca>().buscaLargura(Busca.BUSCA_DEFAULT);

        busca.buscaLargura(Busca.BUSCA_DEFAULT);

        if (busca.GetComponent<Busca>().achouMeta == false)
        {
            Debug.Log("Não achou resultado.");
        }
        else
        {
            Debug.Log("Achou");

            foreach (Nodo n in busca.GetComponent<Busca>().solucao)
            {
                solucao.Add(n._state);
            }

            atual = solucao.Count - 1;
        }
    }
}
