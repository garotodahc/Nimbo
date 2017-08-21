using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class itemDataBase : MonoBehaviour {

	public List<itemScript> itens = new List<itemScript>();
	// Use this for initialization
	void Start () {
		itens.Add (new itemScript("Poçao Agua", 0, "Poçao que ajudaa nuvem a se recuperar",2, 0, itemScript.ItemType.Agua ));
		itens.Add (new itemScript("Pote2", 1, "Poçao que faz a nuvem soltar raios",2, 0, itemScript.ItemType.Eletrico ));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
