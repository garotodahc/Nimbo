using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventario : MonoBehaviour {

	public int slotsX, slotsY;
	public List<itemScript> inventario = new List<itemScript>();
	public List<itemScript> slots = new List<itemScript>();
	private itemDataBase dataBase;
	private bool showInventario;


	// Use this for initialization
	void Start () {

		for(int i = 0;  i < slotsX *slotsY; i++){
			slots.Add(new itemScript());
		}

		//inventario.Add ();
		dataBase = GameObject.FindGameObjectWithTag("item_DataBase").GetComponent<itemDataBase>();
		inventario.Add (dataBase.itens[0]);
		inventario.Add (dataBase.itens[1]);
		inventario.Add (dataBase.itens[2]);
	}

	void Update()
	{
		if(Input.GetButtonDown("Inventario"))
		{
			showInventario = !showInventario;
		}
	}
	// Update is called once per frame
	void OnGUI () 
	{
		if(showInventario)
		{
			desenhoInventario();
		}


	}

	void desenhoInventario()
	{
		for(int x = 0; x< slotsX; x++)
		{
			for(int y =0; y< slotsX; y++)
			{
				GUI.Box(new Rect(x*20, y * 20, 20, 20), y.ToString());
			}
		}
	}
}
