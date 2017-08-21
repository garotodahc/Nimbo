using UnityEngine;
using System.Collections;

public class TutorialInputScript : MonoBehaviour
{

    public GameObject nuvem;
    public Collider2D colisor;
    private ParticleSystem raio;
    public AudioSource audioThunder;
    private ParticleSystem chuva;
    public AudioSource audioRain;
    public Camera camera;
    //public StatusScript status;
    //public AudioSource noItem;

    private static float velocidade;
    //private static float incremento = 0.03f;
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
            audioThunder.Play();            
            raio.Play();            
            colisor.gameObject.transform.localScale = new Vector3(2, 10, 1);
            colisor.enabled = true;                        
        }

        if (Input.GetMouseButtonDown(1))
        {
            audioRain.Play();            
            chuva.Play();
            colisor.gameObject.transform.localScale = new Vector3(2, 2, 1);
            colisor.enabled = true;                        
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (nuvem.transform.position.y <= camera.transform.position.y + 2.5f)
            {
                nuvem.transform.Translate(0, velocidade, 0);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (nuvem.transform.position.y >= camera.transform.position.y + 1.0f)
            {
                nuvem.transform.Translate(0, -velocidade, 0);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (nuvem.transform.position.x >= camera.transform.position.x - 3.9f)
            {
                nuvem.transform.Translate(-velocidade, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (nuvem.transform.position.x <= camera.transform.position.x + 3.9f)
            {
                nuvem.transform.Translate(velocidade, 0, 0);
            }
        }
    }
}
