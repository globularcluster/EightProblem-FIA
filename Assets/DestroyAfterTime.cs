using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	void OnEnable()
    {
        Invoke("Destroy", 2f);
    }
	
	// Update is called once per frame
	void Destroy () {

        gameObject.SetActive(false);
	}

    void OnDisable()
    {
        CancelInvoke();
    }
}
