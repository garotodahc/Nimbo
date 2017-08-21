using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public float move;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.transform.Translate(new Vector3(move, 0, 0));
    }
}
