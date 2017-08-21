#pragma strict


function Awake ()
{
    LeaveScene ();
}
 
function LeaveScene ()
{
	//float testeFade = GameObject.Find("_GM").GetComponent<Fade>.BeginFade(1);
    yield WaitForSeconds (2.0);
    Application.LoadLevel("splash1");
}