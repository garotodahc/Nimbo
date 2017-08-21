using UnityEngine;
using System.Collections;

public class itemAgua : MonoBehaviour {

	public static float aguaEnergia;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "nuvem"){

			aguaEnergia = aguaEnergia + 0.5F;
			Destroy(gameObject);
		}
		if (other.gameObject.transform.parent) {
			Destroy (other.gameObject.transform.parent.gameObject);
		} else {
			//	Destroy (other.gameObject);
		}
	}
}
