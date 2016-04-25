using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class Busca : MonoBehaviour {

    public static int BUSCA_DEFAULT = 0;
    public static int BUSCA_FIXA = 1;
    public static int BUSCA_DESPREZA = 2;

    public int profMax;
    public int testados;
    public int _inversoes;

    public int _largAux = 0;

    public bool achouMeta = false;

    public Nodo inicial;
    public Nodo meta;
    public Nodo _current;
    public Nodo meta1;
    public Nodo meta2;

    public List<Nodo> aberto = new List<Nodo> { };
    public List<Nodo> fechado = new List<Nodo> { };
    public List<Nodo> solucao = new List<Nodo> { };
    public List<Nodo> arvore = new List<Nodo> { };

    public int nodoCode = 0;

    public Text display;

    public string soluvel;

    // Use this for initialization
    void Start () {

        int[,] m1 = new int[3, 3]
            {
                {0,1,2},
                {3,4,5},
                {6,7,8}
            };

        int[,] m2 = new int[3, 3]
        {
                {1,2,3},
                {4,5,6},
                {7,8,0}
        };

        meta1 = new Nodo(m1, null);
        meta2 = new Nodo(m2, null);

        

        //MUDAR DEPOIS PARA UMA META FIXA
        meta = new Nodo(GameObject.Find("Entrada").GetComponent<Entrada>().inicial, null);

        profMax = GameObject.Find("Entrada").GetComponent<Entrada>().prof;

    }
	
    public void buscaLargura(int tipo)
    {
        Debug.Log("Iniciando busca em largura");
        //1. Verifica se o problema é solúvel
        if (!isSoluvel(inicial))
        {
            //Console.WriteLine("->INSOLÚVEL\n-->INVERSÕES: " + _inversoes);
            
            return;
        }

       // Console.WriteLine("->SOLÚVEL\n-->INVERSÕES: " + _inversoes + "\n");

        _current = inicial;

        aberto.Add(_current);

        while (aberto.Count > 0 && !achouMeta)
        {
            //Console.WriteLine("Profundidade atual: " + _current.prof);

            if (tipo == BUSCA_DEFAULT)
            {
                if (isMeta_default(_current))
                {
                    break;
                }
            }
            else if (tipo == BUSCA_FIXA)
            {
                if (isMeta_fixa(_current))
                {
                    break;
                }
            }
            else if (tipo == BUSCA_DESPREZA)
            {
                if (isMeta_desprezaVazio(_current))
                {
                    break;
                }
            }

            if (aberto.Count > 0)
            {
                expande(_current);
            }

            aberto.Remove(aberto.First());

            if (aberto.Count > 0)
                _current = aberto.First();
        }

        //9. Se houver resultado é adicionado a cadeia de "pais" a uma pilha
        while (_current != null && achouMeta)
        {
            solucao.Add(_current);
            _current = _current._parent;
        }

        //10. Termina
        //Console.WriteLine("->SOLÚVEL\n-->INVERSÕES: " + _inversoes + "\n");


    }
    public void transfereConteudo()
    {
        inicial = new Nodo(GameObject.Find("Entrada").GetComponent<Entrada>().inicial, null);
    }

    public void buscaProfundidade(int tipo)
    {        
        Debug.Log("Inicando busca em profundidade");

        Debug.Log("valores da matriz na busca...");
        for(int i = 0; i<3; i++)
        {
            for(int j = 0; j<3; j++)
            {
                Debug.Log(inicial._state[i,j]);
            }
        }

        //1. Verifica se o problema é solúvel
        if (!isSoluvel(inicial))
        {
            Console.WriteLine("->INSOLÚVEL\n-->INVERSÕES: " + _inversoes);
            return;
        }

        //2. Define o estado atual
        _current = inicial;

        //3. Adiciona o estado atual na pilha
        aberto.Add(_current);
        arvore.Add(_current);

        //4. Enquanto tiverem estados abertos ou a meta não for encontrada
        while (aberto.Count > 0 && !achouMeta)
        {

            //5. Checa se o estado é meta                  
            if (tipo == BUSCA_DEFAULT)
            {
                if (isMeta_default(_current))
                {
                    break;
                }
            }
            else if (tipo == BUSCA_FIXA)
            {
                if (isMeta_fixa(_current))
                {
                    break;
                }
            }
            else if (tipo == BUSCA_DESPREZA)
            {
                if (isMeta_desprezaVazio(_current))
                {
                    break;
                }
            }


            //6. Se tiverem estados abertos, remove o ultimo
            if (aberto.Count > 0)
            {
                //fechado.Add(aberto.Last());
                aberto.Remove(aberto.Last());


            }


            //7. Se a profundidade máxima não foi alcançada: expande o nó
            if (_current.prof < profMax)
            {
                expande(_current);
            }



            //8. Se tiverem estados abertos seta o topo da pilha como estado atual
            if (aberto.Count > 0)
            {
                _current = aberto.Last();

            }

        }

        Console.WriteLine("Estados Gerados: " + arvore.Count);
        Console.WriteLine("Estados Testados: " + testados);


        if (achouMeta == false && profMax < 30)
        {
            testados = 0;
            profMax++;
            arvore.Clear();
            aberto.Clear();
            solucao.Clear();
            fechado.Clear();
            buscaProfundidade(tipo);
        }

        //9. Se houver resultado é adicionado a cadeia de "pais" a uma pilha
        while (_current != null && achouMeta)
        {
            solucao.Add(_current);
            _current = _current._parent;
        }

        //10. Termina
    }
    public bool isSoluvel(Nodo n)
    {
        List<int> curr = new List<int> { };
        int invers = 0;

        /**
         * Posiciona os valores da matriz em um vetor temporário
         * */
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {

                curr.Add(n._state[i, j]);
            }
        }


        //Conta o numero de inversoes
        for (int i = 0; i < curr.Count; i++)
        {
            if (curr[i] != 0)
            {
                for (int j = i; j < curr.Count; j++)
                {
                    if (curr[j] != 0)
                    {
                        if (curr[i] > curr[j])
                        {
                            invers++;
                        }
                    }
                }
            }
        }

        _inversoes = invers;

        //Checa se é PAR ou IMPAR
        if (invers % 2 == 0)
        {
            soluvel = "É soluvel.";
            return true;
        }

        soluvel = "Não é solúvel.";
        return false;
    }
    public bool isMeta_default(Nodo n)
    {
        testados++;

        bool achou = true;

        if (!(n._state[0, 0] == 0))
        {
            if (!(n._state[0, 0] == 1))
            {
                return false;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (achou == false) break;
            for (int j = 0; j < 3; j++)
            {
                if (n._state[i, j] != meta1._state[i, j])
                {
                    achou = false;
                }
            }
        }

        if (achou == false)
        {
            achou = true;

            for (int i = 0; i < 3; i++)
            {
                if (achou == false) break;

                for (int j = 0; j < 3; j++)
                {
                    if (n._state[i, j] != meta2._state[i, j])
                    {
                        achou = false;
                    }
                }
            }
        }

        if (achou == false)
        {
            return false;
        }

        achouMeta = true;
        return true;
    }
    /**
     * Verifica se o puzzle está ordenado, deseprezando o vazio
     * */
    public bool isMeta_desprezaVazio(Nodo n)
    {
        testados++;

        List<int> temp = new List<int> { };

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {

                temp.Add(n._state[i, j]);
            }
        }

        for (int i = 0; i < temp.Count; i++)
        {

            for (int j = i; j < temp.Count; j++)
            {

                if (temp[j] < temp[i] && temp[i] != 0 && temp[j] != 0)
                {
                    return false;
                }
            }

        }

        achouMeta = true;
        return true;
    }
    /**
     * Verifica se encontrou uma meta fixa
     * */
    public bool isMeta_fixa(Nodo n)
    {
        testados++;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (n._state[i, j] != meta._state[i, j])
                {
                    return false;
                }
            }
        }

        achouMeta = true;
        return true;
    }
    public bool expande(Nodo curr)
    {

        bool _achou = false;

        Nodo _novoUp = new Nodo(curr._state, curr);
        Nodo _novoDown = new Nodo(curr._state, curr);
        Nodo _novoRight = new Nodo(curr._state, curr);
        Nodo _novoLeft = new Nodo(curr._state, curr);

        //Branco move pra cima
        if (_novoUp.moveUp())
        {
            if (!equalPrevious(_novoUp, curr))
            {
                nodoCode++;
                _novoUp.code = nodoCode;

                aberto.Add(_novoUp);
                arvore.Add(_novoUp);

                _achou = true;
            }
        }

        //Branco move pra baixo
        if (_novoDown.moveDown())
        {
            if (!equalPrevious(_novoDown, curr))
            {
                nodoCode++;
                _novoDown.code = nodoCode;

                aberto.Add(_novoDown);
                arvore.Add(_novoDown);
                _achou = true;
            }
        }

        //Branco move para direita
        if (_novoRight.moveRight())
        {
            if (!equalPrevious(_novoRight, curr))
            {
                nodoCode++;
                _novoRight.code = nodoCode;

                aberto.Add(_novoRight);
                arvore.Add(_novoRight);
                _achou = true;
            }
        }

        //Branco move para a esquerda
        if (_novoLeft.moveLeft())
        {
            if (!equalPrevious(_novoLeft, curr))
            {
                nodoCode++;
                _novoLeft.code = nodoCode;

                aberto.Add(_novoLeft);
                arvore.Add(_novoLeft);
                _achou = true;
            }
        }
        return _achou;
    }
    public bool equalPrevious(Nodo n, Nodo curr)
    {
        if (curr._parent == null)
        {
            return false;
        }


        Nodo _tmp = curr._parent;
        bool result = true;
        while (_tmp != null)
        {
            result = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (n._state[i, j] != curr._parent._state[i, j])
                    {
                        result = false;
                    }
                }
            }

            _tmp = _tmp._parent;

        }

        return result;
    }
    
}
