using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{

    public GameObject[] obj;
    public float spawnTime;
    public bool floor;
    public int chanceArvore;
    
    public static readonly float decreaseTimeToSpaw = 0.2f;
    public float multiplicadorIncremento = 0;//De acordo com nível. nivel*incremento [1*decreasetimeToSpaw] ou 2[2*decreasetimeToSpaw]
    private float controle = 0;

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("Spawn", spawnMin, spawnMax);
        Invoke("Spawn", spawnTime);
    }



    // Update is called once per frame
    void Spawn()
    {

        if (floor)
        {
            int chance = Random.Range(0, 100);
            if (chance < chanceArvore)
            {
                //cria árvores
                Instantiate(obj[obj.GetLength(0) - 1], transform.position, Quaternion.identity);
            }
            else
            {
                //Cria os inimigos
                int aux = Random.Range(0, obj.GetLength(0) - 1);

                if (obj[aux].tag.Equals("Floor"))
                {                    
                    if(obj[aux].name.Contains("Montanha"))
                    {
                        Instantiate(obj[aux], new Vector3(transform.position.x, 0), Quaternion.identity);
                    }
                    else 
                    {
                        Instantiate(obj[aux], new Vector3(transform.position.x, 0.3f), Quaternion.identity);                        
                    }
                        
                }
                else
                {                    
                        Instantiate(obj[aux], new Vector3(transform.position.x, transform.position.y), Quaternion.identity);                    
                }                
                //Correção de velocidade, qnd for o incendiario.
                //float increase = 0.5f;
                //if (aux == 1)
                //{
                //    increase += 0.2f;
                //}
                Invoke("Spawn", spawnTime);
                return;

            }
        }
        else
        {
            //Cria GOTA/RAIO
            Instantiate(obj[Random.Range(0, obj.GetLength(0))], new Vector3(transform.position.x, (Random.Range(10, 44) / 10)), Quaternion.identity);
        }

        Invoke("Spawn", spawnTime);
        controle += spawnTime;
        //Esse if fará com que os objetos do chão/céu sejam mais rapidamente a medida que avelocidade de deslocamento deles aumente.
        if (controle >= HOrizontalMOve.timeToUpdateInSeconds)
        {
            ResetInvokeScheme();
            controle = 0;
        }

    }

    public void ResetInvokeScheme()
    {
        //Debug.Log("ResetInvokeScheme() | ANTES: spawnTime= " + spawnTime);
        spawnTime -= (decreaseTimeToSpaw * multiplicadorIncremento);
        //Debug.Log("ResetInvokeScheme() | DEPOIS: spawnTime= " + spawnTime);
        if (spawnTime <= 1f)
        {
            spawnTime = 1f;
        }

    }
}
