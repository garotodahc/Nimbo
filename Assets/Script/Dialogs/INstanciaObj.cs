using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class INstanciaObj : MonoBehaviour
{

    // Use this for initialization
    /*
	 * avisos[0] = Area de recarga
	 * avisos[1] = Desmatamento
	 * avisos[2] = Fábrica
	 * avisos[3] = Lençol Freático
	 * avisos[4] = Mata atlantica
	 * avisos[5] = Nascente
	 * avisos[6] = Queimadas
	 * avisos[7] = Seca

	 */
    public List<GameObject> avisos = new List<GameObject>();
    public bool pausa = true;
    private static bool criou = false;
    void Start()
    {
        StartCoroutine(OnUnPaused());

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (GameObject.Find("Lenhador-01(Clone)"))
        {
            if (!criou)
            {
                Instantiate(avisos[1], new Vector3(0.83f, 2f, 0.0f), Quaternion.identity);
                criou = true;
            }
            if (GameObject.FindWithTag("inimigo").transform.position.x <= -1.48f)
            {
                OnUnPaused();
                Destroy(GameObject.Find("Lenhador-01(Clone)"));
                criou = false;
            }
        }

        if (GameObject.Find("Fabrica_0(Clone)"))
        {
            if (!criou)
            {
                Instantiate(avisos[2], new Vector3(0.83f, 2f, 0.0f), Quaternion.identity);
                criou = true;
            }
            if (GameObject.FindWithTag("inimigo").transform.position.x <= -0.48f)
            {
                OnUnPaused();
                Destroy(GameObject.Find("Fabrica_0(Clone)"));
                criou = false;

              //  Application.LoadLevel("OptionsScene");
            }
        }
        if (GameObject.Find("Incendiario-01(Clone)"))
        {
            if (!criou)
            {
                Instantiate(avisos[6], new Vector3(0.83f, 2f, 0.0f), Quaternion.identity);
                criou = true;
            }
            if (GameObject.FindWithTag("inimigo").transform.position.x <= -1.48f)
            {
                OnUnPaused();
                Destroy(GameObject.Find("Incendiario-01(Clone)"));
                criou = false;
            }

           
            }
        }
    


    IEnumerator OnUnPaused()
    {

        while (pausa)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (Time.timeScale == 0)
                {

                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
            yield return null;
        }


    }
}
