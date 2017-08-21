using UnityEngine;
using System.Collections;

public class nuvemScript : MonoBehaviour {

	public StatusScript status;
    public AudioSource audioRain;
    public AudioSource audioThunder;
    public ParticleSystem raio;
    public ParticleSystem chuva;
	public Animator meuAnimator;
    public int count = 0;

	// Use this for initialization
	void Start () 
	{
		meuAnimator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //verifica todo frame a condição para setar a animação
        if (status.GetRaio() == 0) {
            meuAnimator.SetBool("ItemRaio", false);
            meuAnimator.SetInteger("QtdeRaio", 0);
        }

        if (status.GetChuva() == 0)
        {
            meuAnimator.SetBool("ItemAgua", false);
            meuAnimator.SetInteger("QtdeChuva", 0);
        }
        verificaCount();


    }


    public void verificaCount() {

        switch (count)
        {
            case 1:
                meuAnimator.SetBool("Itemdano", true);
                meuAnimator.SetBool("Itemdano2", false);
                meuAnimator.SetBool("Itemdano3", false);
                meuAnimator.SetBool("Itemdano4", false);
                meuAnimator.SetBool("Itemdano5", false);
                break;
            case 2:
                meuAnimator.SetBool("Itemdano", false);
                meuAnimator.SetBool("Itemdano2", true);
                meuAnimator.SetBool("Itemdano3", false);
                meuAnimator.SetBool("Itemdano4", false);
                meuAnimator.SetBool("Itemdano5", false);
                break;
            case 3:
                meuAnimator.SetBool("Itemdano", false);
                meuAnimator.SetBool("Itemdano2", false);
                meuAnimator.SetBool("Itemdano3", true);
                meuAnimator.SetBool("Itemdano4", false);
                meuAnimator.SetBool("Itemdano5", false);
                break;
            case 4:
                meuAnimator.SetBool("Itemdano", false);
                meuAnimator.SetBool("Itemdano2", false);
                meuAnimator.SetBool("Itemdano3", false);
                meuAnimator.SetBool("Itemdano4", true);
                meuAnimator.SetBool("Itemdano5", false);
                break;
            case 5:
                meuAnimator.SetBool("Itemdano", false);
                meuAnimator.SetBool("Itemdano2", false);
                meuAnimator.SetBool("Itemdano3", false);
                meuAnimator.SetBool("Itemdano4", false);
                meuAnimator.SetBool("Itemdano5", true);
                break;
            default:
                meuAnimator.SetBool("Itemdano", false);
                meuAnimator.SetBool("Itemdano2", false);
                meuAnimator.SetBool("Itemdano3", false);
                meuAnimator.SetBool("Itemdano4", false);
                meuAnimator.SetBool("Itemdano5", false);
                break;
        }
    
}


void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Chuva(Clone)")
        {
            audioRain.Play();
            status.SetChuva(status.GetChuva() + 1);
            status.statusChuva.text = status.GetChuva().ToString();

            meuAnimator.SetBool("ItemAgua", true);


            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "Raio(Clone)")
        {
            audioThunder.Play();
            status.SetRaio(status.GetRaio() + 1);
            status.statusRaio.text = status.GetRaio().ToString();
            meuAnimator.SetBool("ItemRaio", true);
            meuAnimator.SetInteger("QtdeRaio", status.GetRaio());


            Destroy(other.gameObject);

        }

        if (other.gameObject.name == "Predio(Clone)" || other.gameObject.name == "Montanha(Clone)" || other.gameObject.name == "Celeiro(Clone)")
        {
            if (!other.gameObject.GetComponent<StaticEnemieScrip>().GetTrue())
            {
                StaticEnemieScrip script = other.gameObject.GetComponent<StaticEnemieScrip>();
                script.SetTrue();
                script.batendo.Play();
                if (status.GetVida() == 0)
                {
                    status.SetVida(-1);
                    meuAnimator.SetInteger("QtdeVidas", 0); //executa a animação de morrendo
                                                            //  meuAnimator.SetBool("Itemdano",true);

                }
                else
                {
                    status.SetVida(-1);
                    status.statusVida.text = status.GetVida().ToString();
                    count = count + 1;
                    // meuAnimator.SetBool("Itemdano", true);
                    meuAnimator.SetInteger("QtdeVidas", status.GetVida());
                    status.SetLP(500);
                    status.SetPontos(-100);
                    status.statusPontos.text = status.GetPontos().ToString();

                }
            }
        }

        if (other.name == "Lenhador-01(Clone)")
        {

            if (raio.isPlaying && !other.gameObject.GetComponent<lenhadorScript>().GetTrue())
            {
                other.gameObject.GetComponent<lenhadorScript>().SetTrue();
                status.SetLencol(5);
                status.SetPontos(100);
            }
        }

        if (other.name == "Incendiario-01(Clone)")
        {

            if (chuva.isPlaying && !other.gameObject.GetComponent<enemiesAnimScript>().GetTrue())
            {
                other.gameObject.GetComponent<enemiesAnimScript>().SetTrue();
                status.SetLencol(5);
                status.SetPontos(100);
            }
        }

        if (other.name == "Fabrica_0(Clone)")
        {
            if (raio.isPlaying && !other.gameObject.GetComponent<fabricaScript>().GetTrue())
            {
                other.gameObject.GetComponent<AudioSource>().Play();
                other.gameObject.GetComponent<fabricaScript>().SetTrue();
                status.SetLencol(5);
                status.SetPontos(100);
            }
        }

    }
}
