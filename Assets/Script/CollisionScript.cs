using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {


    
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Lenhador-01(Clone)")
        {
            Debug.Log("Colidiu raio");
            //other.gameObject SetBool("ItemUsado", true);
            //	Destroy(gameObject);
        }
    }
}
