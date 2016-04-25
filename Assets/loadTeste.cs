using UnityEngine;
using System.Collections;

public class loadTeste : MonoBehaviour {

    public GameObject load;
    bool on_off = false;

    public void activeLoad()
    {
        load.SetActive(!on_off);
        on_off = !on_off;
    }
}
