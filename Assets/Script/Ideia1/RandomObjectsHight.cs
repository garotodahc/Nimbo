using UnityEngine;
using System.Collections;

public class RandomObjectsHight : MonoBehaviour {


	float heightTop = 4.4f;
	float heightBtm = 1.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update() {
	
		if(transform.position.y <= heightTop ){
		//	heightBtm = transform.position.y ;
			float altura = transform.position.y;
			altura = Random.Range(heightTop,heightBtm);
		}
	}
}
