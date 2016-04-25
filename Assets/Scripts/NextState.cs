using UnityEngine;
using System.Collections;

public class NextState : MonoBehaviour {

    Busca busca;
    Nodo currentState;
    
    public GameObject entrada;
    public Transform[] slots;

    public bool primeira = true;
    public bool restaSolucoes = true;

    int m = 0;
    int i = 0;
    int j = 0;

    void Start()
    {
        busca = GameObject.Find("Busca").GetComponent<Busca>();
        
    }

  
    public void nextStateClicked()
    {
        
        if (primeira)
        {
            m = busca.solucao.Count-2;
            primeira = false;
            
        }

        Debug.Log("solucao.count = " + m);

        if (restaSolucoes)
        {
            currentState = busca.solucao[m];
            Debug.Log("Tamanho de Slots = " + slots.Length);
            for (int k = 0; k < slots.Length; k++)
            {
                Debug.Log("Analisando posicao [" + i + "][" + j + "]");
                Debug.Log("current state:" + currentState._state[i, j]);

                if (currentState._state[i, j] != 0)
                {
                    GameObject item = GameObject.Find("item_" + currentState._state[i, j]);
                    Debug.Log("item =" + item);

                    item.transform.SetParent(slots[k]);
                    item.transform.localPosition = new Vector2(0, 0);
                }

                j = (j + 1) % 3;
                if (j == 0)
                {
                    i = (i + 1) % 3;
                }
            }

            m--;
            //se m atingiu o limite de solucoes
            if (m < 0)
            {
                restaSolucoes = false;
                Debug.Log("Atingiu Limite de solucoes");
                m = 0; //so pra garantir
                gameObject.SetActive(false);

            }
        }

       


    }

}
