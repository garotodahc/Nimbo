using UnityEngine;
using System.Collections;

public class CloudMove : MonoBehaviour
{

    int deslo = 10;

    float limiteSup = 4.4f;
    float limiteInf = 1.0f;
    float limiteDireito = 6.75f;
    float limiteEsquerdo = -6.52f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {

        /*Limitando sem a exitencia de colisores*/
        if (transform.position.y <= limiteSup)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, deslo * Time.deltaTime, 0);

            }
        }
        if (transform.position.y >= limiteInf)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -deslo * Time.deltaTime, 0);
            }
        }
        if (transform.position.x >= limiteEsquerdo)
        {
            if (Input.GetKey("left"))
            {
                transform.Translate(-deslo * Time.deltaTime, 0, 0);

            }
        }

        if (transform.position.x <= limiteDireito)
        {
            if (Input.GetKey("right"))
            {
                transform.Translate(deslo * Time.deltaTime, 0, 0);

            }
        }



    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "item_DataBase")
        {
            Destroy(other.gameObject.transform.parent.gameObject);

            return;
        }

        if (other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else
        {
            //	Destroy (other.gameObject);
        }
    }
}
