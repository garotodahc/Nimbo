using UnityEngine;
using System.Collections;

public class SegueMouseClick : MonoBehaviour {
	private Vector3 mousePosition;
	public float moveSpeed = 0.1f;
	//private int timer = 10;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		segueMouse();		
	}

	void segueMouse(){
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
	}


	/*void OnTriggerEnter2D(Collider other){

		if(other.gameObject.transform.parent){
			MenuTerrain.objetosLista.Add(gameObject);
			Destroy(other.gameObject);
		}
	}*/
}