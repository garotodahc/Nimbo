using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class buttonScript : MonoBehaviour
{


    public List<GameObject> list = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        //Instantiate (list [0], new Vector3 (0.83f, 2f, 0.0f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeGameObject()
    {


        //for (int i = 0; i <= list.Count; i++)
        //{

        int j = Random.Range(0, 5);
        //int sorteado = j;
        //bool instanciado = false;
        /*	if(sorteado == ){

            }*/
        GameObject go = Instantiate(list[j], new Vector3(0.83f, 2f, 0.0f), Quaternion.identity) as GameObject;

        //break;


        //}
    }
}
