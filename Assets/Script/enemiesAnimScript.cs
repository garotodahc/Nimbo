﻿using UnityEngine;
using System.Collections;
using System;

public class enemiesAnimScript : MonoBehaviour
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
            enemieAnimator.SetBool("DeixouPassar", deixouPassar);
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

            enemieAnimator.SetBool("UsouItem", true);
        }
        /*	if(posicaoObjeto.transform.position.x  == -3.0f && itemUsado == true ){
                deixouPassar = false;
                enemieAnimator.SetBool("UsouItem", itemUsado);
                enemieAnimator.SetBool("DeixouPassar", deixouPassar);
            }*/
    }

    public void SetTrue()
    {
        itemUsado = true;
    }

    public bool GetTrue()
    {
        return itemUsado;
    }



}
