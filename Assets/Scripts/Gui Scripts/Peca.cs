using UnityEngine;
using System.Collections;

public class Peca : MonoBehaviour {

    public int id_i;
    public int id_j;
    public GameObject peca; 

	// Use this for initialization
	void Start () {

        atualiza(id_i, id_j);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void atualiza(int i, int j)
    {
        id_i = i;
        id_j = j;

        Vector3 pos;
        pos.x = id_i * 0.6f ;
        pos.y = -id_j * 0.6f;
        pos.z = 0;

        peca.transform.position = pos;
    }
}
