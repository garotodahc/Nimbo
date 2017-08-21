using UnityEngine;
using System.Collections;

public class intanciadordeAvisos : MonoBehaviour
{

    public GameObject[] aviso;
    public float tempo = 20f;
    public int contador = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        tempo = tempo - Time.deltaTime;

        if (tempo <= 0)
        {
            contador = contador + 1;
            instacia();
            tempo = 10;
        }
        //Debug.Log ("Tempo: "+ tempo);
    }


    void instacia()
    {
        if (contador == 1)
        {

            Instantiate(aviso[0], new Vector3(0, 1.28f, -0.24f), Quaternion.identity);
        }
        if (contador == 2)
        {
            Instantiate(aviso[1], new Vector3(0, 1.28f, -0.24f), Quaternion.identity);
        }
        if (contador == 3)
        {
            Instantiate(aviso[2], new Vector3(0, 1.28f, -0.24f), Quaternion.identity);
        }
        if (contador == 4)
        {
            Instantiate(aviso[3], new Vector3(0, 1.28f, -0.24f), Quaternion.identity);
        }
        if (contador == 5)
        {
            Instantiate(aviso[4], new Vector3(0, 1.28f, -0.24f), Quaternion.identity);
        }
        if (contador == 6)
        {
            Instantiate(aviso[5], new Vector3(0, 1.28f, -0.24f), Quaternion.identity);
        }
        if (contador == 7)
        {
            Instantiate(aviso[6], new Vector3(0, 1.28f, -0.24f), Quaternion.identity);
        }
        if (contador == 8)
        {
            Application.LoadLevel("MenuScene");
        }
        

    }

}

