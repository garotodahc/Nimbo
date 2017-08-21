using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class powers : MonoBehaviour {

	public GameObject obj;
	public int qtdeRaios;
	public GameObject obj2;
	public EventSystem events;

	// Use this for initialization
	void Start () {
	//	obj = GetComponent<GameObject> ();
	//	posObj = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {

				GameObject clone;
			clone = Instantiate (obj,obj2.gameObject.transform.position, obj2.gameObject.transform.rotation) as GameObject;
				//Destroy(obj,0.1f);

			}

		if(Input.GetMouseButtonUp(0)){

			Destroy(obj);
		}
	}
}
