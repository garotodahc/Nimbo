//#pragma strict
import System.Collections.Generic;
 
 
var tempo =2.0; 
function Start () {

  
}

function Update () {

	tempo = tempo -Time.deltaTime;

	if(tempo <= 0.0){

	   Destroy(gameObject); 
	   }
}