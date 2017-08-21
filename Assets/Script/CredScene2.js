#pragma strict

var pos : float;
var velocidade : float;
var tempo: float;
function Start () {

velocidade =1.0f;
pos =1.46f; 
}
 
function Update () {

transform.Translate (0, velocidade * Time.deltaTime, 0);

		if(pos >= 1.46f){
			
			LeaveScene ();
		}
}


function LeaveScene ()
{
    yield WaitForSeconds (tempo);
    Application.LoadLevel("MenuScene");
}