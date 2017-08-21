using UnityEngine;
using System.Collections;

public class instanceTutorial : MonoBehaviour
{


    //esse script controla os objetos intanciados para aparecer avisos
    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
    public bool floor;
    public int count = 0;

    // Use this for initialization
    void Start()
    {

        InvokeRepeating("Spawn", spawnMin, spawnMax);

    }

    void Uptade()
    {

        if (count > 4)
        {
            CancelInvoke();

        }

    }

    // Update is called once per frame
    void Spawn()
    {

        count = count + 1;
        Debug.Log("CONTADOR = " + count);
        if (floor && count != 4)
        {

            //Debug.Log ("Count" + count);
            Instantiate(obj[count], new Vector3(5.67f, -1.04f, -0.24f), Quaternion.identity);
            Time.timeScale = 0;

        }
        else if (floor && count == 4)
        {
            Application.LoadLevel("OptionsScene");
       }
        else
        {
            Instantiate(obj[Random.Range(0, obj.GetLength(0))], new Vector3(6.07f, -1.36f, -0.24f), Quaternion.identity);
            //Invoke("spawn", Random.Range (spawnMin,spawnMax));
        }
    }
}
