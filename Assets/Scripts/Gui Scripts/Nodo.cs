using UnityEngine;
using System.Collections;

public class Nodo {

        public int[,] _state = new int[3, 3];
        public Nodo _parent;
        public int prof = 1;
        public int code;

        public Nodo(int[,] _param, Nodo p)
        {
            if (p != null)
            {
                _parent = p;
                prof = _parent.prof + 1;
            }


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _state[i, j] = _param[i, j];
                }
            }
        }
        public void mostraValores()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Debug.Log(_state[i, j]);
                }
            Debug.Log("\n");
            }
        }
        public bool moveUp()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_state[i, j] == 0)
                    {
                        if (i > 0)
                        {
                            int _valor = _state[i - 1, j];
                            _state[i - 1, j] = 0;
                            _state[i, j] = _valor;

                            return true;
                        }
                        else
                        {
                            //Console.WriteLine("[Impossivel mover acima]");
                        }
                    }
                }
            }

            return false;
        }
        public bool moveDown()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_state[i, j] == 0)
                    {
                        if (i < 2)
                        {
                            int _valor = _state[i + 1, j];
                            _state[i + 1, j] = 0;
                            _state[i, j] = _valor;

                            return true;
                        }
                        else
                        {
                            //Console.WriteLine("[Impossivel mover abaixo]");
                        }
                    }
                }
            }

            return false;
        }
        public bool moveRight()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_state[i, j] == 0)
                    {
                        if (j < 2)
                        {
                            int _valor = _state[i, j + 1];
                            _state[i, j + 1] = 0;
                            _state[i, j] = _valor;

                            return true;
                        }
                        else
                        {
                            //Console.WriteLine("[Impossivel mover a direita]");
                        }
                    }
                }
            }

            return false;
        }
        public bool moveLeft()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_state[i, j] == 0)
                    {
                        if (j > 0)
                        {
                            int _valor = _state[i, j - 1];
                            _state[i, j - 1] = 0;
                            _state[i, j] = _valor;

                            return true;
                        }
                        else
                        {
                            //Console.WriteLine("[Impossivel mover a esquerda]");
                        }
                    }
                }
            }

            return false;
        }
    
}
