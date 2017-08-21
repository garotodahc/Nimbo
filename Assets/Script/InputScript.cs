using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour
{

    public GameObject nuvem;
    public Collider2D colisor;
    private ParticleSystem raio;
    public AudioSource audioThunder;
    private ParticleSystem chuva;
    public AudioSource audioRain;
    public StatusScript status;
    public AudioSource noItem;

    private static float velocidade;
    private static float incremento = 0.03f;
    private float boxing = 0.06f;

    // Use this for initialization
    void Start()
    {
        ParticleSystem[] particles = nuvem.GetComponentsInChildren<ParticleSystem>();
        raio = particles[0];
        chuva = particles[1];
        velocidade = 0.1f;
    }

    // Update is called once per frame

    public static void IncreaseNimboSpeed(float multiplicador)
    {
        velocidade += multiplicador * incremento;
        //Debug.Log("IncreaseNimboSpeed || velocidade = " + velocidade);
    }

    void Update()
    {
        if (!raio.isPlaying && !chuva.isPlaying)
        {
            colisor.enabled = false;
        }
        else if (chuva.isPlaying) 
        {
            colisor.gameObject.transform.localScale = new Vector3(2, colisor.gameObject.transform.localScale.y + boxing, 1);
        }

        if (Input.GetMouseButtonDown(0))
        {
            /*if (!raio.isPlaying && !chuva.isPlaying && !audioThunder.isPlaying && !audioRain.isPlaying)
            {*/
            if (status.GetRaio() > 0)
            {
                audioThunder.Play();
                status.SetRaio(status.GetRaio() - 1);
                raio.Play();
                status.statusRaio.text = status.GetRaio().ToString();
                colisor.gameObject.transform.localScale = new Vector3(2, 10, 1);
                colisor.enabled = true;
            }
            else
                noItem.Play();
            //}
        }

        if (Input.GetMouseButtonDown(1))
        {
            /*if (!raio.isPlaying && !chuva.isPlaying && !audioThunder.isPlaying && !audioRain.isPlaying)
            {*/
            if (status.GetChuva() > 0)
            {
                audioRain.Play();
                status.SetChuva(status.GetChuva() - 1);
                chuva.Play();
                status.statusChuva.text = status.GetChuva().ToString();
                colisor.gameObject.transform.localScale = new Vector3(2, 2, 1);
                colisor.enabled = true;
            }
            else
                noItem.Play();
            //}
        }

        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
        {
            if (nuvem.transform.position.y <= 4.4f)
            {
                nuvem.transform.Translate(0, velocidade, 0);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (nuvem.transform.position.y >= 1.0f)
            {
                nuvem.transform.Translate(0, -velocidade, 0);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (nuvem.transform.position.x >= -6.52f)
            {
                nuvem.transform.Translate(-velocidade, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (nuvem.transform.position.x <= 6.75f)
            {
                nuvem.transform.Translate(velocidade, 0, 0);
            }
        }
    }
}
