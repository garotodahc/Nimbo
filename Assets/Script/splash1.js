#pragma strict

function Awake ()
{
    LeaveScene ();
}
 
function LeaveScene ()
{
    yield WaitForSeconds (3.0);
    Application.LoadLevel("splash2");
}