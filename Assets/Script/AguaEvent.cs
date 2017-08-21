using UnityEngine;
using System.Collections;

public class AguaEvent : MonoBehaviour {


	private float nivel = 0;
	float nivelMin = -5.93f;
	float limiteSup = -3.52f;

	// Use this for initialization
	void Start () {
		nivel = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		desceAgua ();
		atualizaNivelAgua ();

		if(transform.position.y < nivelMin){

			//transform.position = new Vector3(-0.05f,-3.52f,0f);
			Debug.LogWarning("Perdeu jogo");
  		}
		if(transform.position.y >= limiteSup){
			
			transform.position = new Vector3(-0.05f,-3.52f,0f);
			Debug.LogWarning("Continua Jogo");
			itemAgua.aguaEnergia = 0;
		}
		atualizaNivelAgua ();

	}

	void atualizaNivelAgua(){
		nivel = nivel + itemAgua.aguaEnergia;
	}

	void desceAgua(){
		nivel = (nivel - 0.25F) * Time.deltaTime;
		transform.Translate (0, nivel,0);
	}
}
