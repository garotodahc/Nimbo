using UnityEngine;
using System.Collections;
using System;

public class lenhadorScript : MonoBehaviour
{

    public GameObject posicaoObjeto;
    public Animator enemieAnimator;
    private bool itemUsado = false;
    private bool deixouPassar = false;
    public AudioSource arvore;
    public AudioSource caindo;
    private StatusScript status;

    // Use this for initialization
    void Start()
    {
        enemieAnimator = GetComponent<Animator>();
        itemUsado = false;
        deixouPassar = false;
        status = GameObject.Find("EventSystem").GetComponentInChildren<StatusScript>();
    }

    // Update is called once per frame
    void Update()
    {


        if (posicaoObjeto.transform.position.x <= -6.0f && !arvore.isPlaying && !caindo.isPlaying && !itemUsado)
        {
            arvore.Play();
            caindo.Play();
            deixouPassar = true;
            enemieAnimator.SetBool("Passou", deixouPassar);
            //Debug.Log("Passouoooooooooooooo");
            try
            {
                status.SetLencol(-10);
                status.SetLP(100);
                status.SetPontos(-200);
            }
            catch (NullReferenceException e) { }
        }

        if (itemUsado == true)
        {

            enemieAnimator.SetBool("ItemUsado", true);

        }
        /*	if(posicaoObjeto.transform.position.x  == -3.0f && itemUsado == true ){
			deixouPassar = false;
			enemieAnimator.SetBool("UsouItem", itemUsado);
			enemieAnimator.SetBool("DeixouPassar", deixouPassar);
		}*/
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{

    //    if (other.name == "Thunder(Clone)")
    //    {
    //        Debug.Log("Colidiu raio");
    //        enemieAnimator.SetBool("ItemUsado", true);
    //        //	Destroy(gameObject);
    //    }

    //}

    public void SetTrue()
    {
        itemUsado = true;
    }

    public bool GetTrue()
    {
        return itemUsado;
    }



    //void OnTriggerEnter2D(Collider2D other){

    //    if (other.tag == "particula") {
    //        Debug.Log ("Colidiu raio");
    //        enemieAnimator.SetBool("ItemUsado", true);
    //    //	Destroy(gameObject);
    //    }

    //}
}
