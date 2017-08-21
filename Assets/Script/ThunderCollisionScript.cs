using UnityEngine;
using System.Collections;

public class ThunderCollisionScript : MonoBehaviour {

    public StatusScript status;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnParticleCollision(GameObject other)
    {
        if (other.name == "Lenhador-01(Clone)" && !other.GetComponentInChildren<lenhadorScript>().GetTrue())
        {
            other.GetComponent<lenhadorScript>().SetTrue();
            status.SetLencol(10);
        }
    }
}

