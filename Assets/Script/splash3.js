#pragma strict
function Awake ()
{
    LeaveScene ();
}
 
function LeaveScene ()
{
    yield WaitForSeconds (2.0);
    Application.LoadLevel("splash4");
}