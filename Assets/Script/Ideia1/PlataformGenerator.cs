using UnityEngine;
using System.Collections;

public class PlataformGenerator : MonoBehaviour {

	public GameObject[] plataformVectorAll;
	public GameObject plataformaAtual;
	// Use this for initialization
	void Start () {
		plataformaAtual = (GameObject)Instantiate (plataformaAtual, transform.position + transform.up* -2, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
