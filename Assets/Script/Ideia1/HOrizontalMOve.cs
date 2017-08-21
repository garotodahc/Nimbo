using UnityEngine;
using System.Collections;

public class HOrizontalMOve : MonoBehaviour
{

    //float tempo = 5.0f;
    public static float desloLat = 1.8f;
    public static float incremento = 0.2f;
    public float multiplicadorIncremento = 0f;//De acordo com nível. nivel*incremento [1*0,2] ou 2[2*0,2]
    public static float positionCamera;
    // Use this for initialization

    private bool canEnter = true;
    public static float timeToUpdateInSeconds = 8;
    public bool naoAcelerar = false;

    void Start()
    {

    }

    void UptadeSpeed()
    {

        desloLat = desloLat + (multiplicadorIncremento * incremento);
        //Debug.Log("UptadeSpeed - desloLat= " + desloLat);
        //transform.Translate(-desloLat * Time.deltaTime, 0, 0);
        InputScript.IncreaseNimboSpeed(multiplicadorIncremento);//Atualizo a velocidade da nimbo.

        canEnter = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!naoAcelerar)
        {
            if (canEnter)
            {
                canEnter = false;
                //Debug.Log("HOrizontalMOve Update - canEnter= true");
                Invoke("UptadeSpeed", timeToUpdateInSeconds);
            }
        }

        transform.Translate(-desloLat * Time.deltaTime, 0, 0);

        if (gameObject.transform.position.x <= -10)
        {
            Destroy(gameObject);
        }

    }
}
