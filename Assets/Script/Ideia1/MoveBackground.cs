using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour
{

    //private Material meuMatAtual;
    public float velocidade;// = 1.8f;
    public float tamanho;
    private Vector3 posicaoInicial;

    private static float incremento = 0.02f;//Aumenta velocidade em 0.01f
    private bool canEnter = true;
    private float pilha = 0f;
    public bool naoAcelerar = false;

    // Use this for initialization
    void Start()
    {
        posicaoInicial = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        float aux = Time.time * velocidade;
        float novaposicao = Mathf.Repeat(aux, tamanho);

        transform.position = posicaoInicial + Vector3.left * novaposicao;

        if (!naoAcelerar)
            if (canEnter)
            {
                canEnter = false;

                Invoke("IncreaseSpeedBackground", HOrizontalMOve.timeToUpdateInSeconds);
            }

    }

    private float roundNumber(float vr)
    {
        return (float)System.Math.Round(vr, 2);
    }

    public void IncreaseSpeedBackground()
    {
        if (velocidade < 0)
        {
            velocidade -= incremento;
        }
        else
        {
            velocidade += incremento;
        }

        velocidade = roundNumber(velocidade);
        canEnter = true;
        /*//Debug.Log("IncreaseSpeedBackground() | DEPOIS: velocidade= " + velocidade);

        float aux = Time.time * (velocidade - incremento / 3f);

        pilha += incremento - incremento / 3f;

        float novaposicao = Mathf.Repeat(aux, tamanho);

        transform.position = posicaoInicial + Vector3.left * novaposicao;*/

    }

}
