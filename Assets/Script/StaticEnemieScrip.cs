using UnityEngine;
using System.Collections;

public class StaticEnemieScrip : MonoBehaviour
{

    public GameObject posicaoObjeto;
    private bool bateu = false;
    private bool passou = false;
    public AudioSource batendo;
    private StatusScript status;

    // Use this for initialization
    void Start()
    {
        bateu = false;
        passou = false;
        status = GameObject.Find("EventSystem").GetComponentInChildren<StatusScript>();
        posicaoObjeto.transform.position = new Vector3(posicaoObjeto.transform.position.x, posicaoObjeto.transform.position.y, posicaoObjeto.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (posicaoObjeto.transform.position.x <= -6.0f && !bateu && !passou)
        {            
            status.SetPontos(200);
            status.statusPontos.text = status.GetPontos().ToString();
            passou = true;
        }        

        //if(itemUsado == true){

        //    enemieAnimator.SetBool("UsouItem", true);
        //} 
        /*	if(posicaoObjeto.transform.position.x  == -3.0f && itemUsado == true ){
                deixouPassar = false;
                enemieAnimator.SetBool("UsouItem", itemUsado);
                enemieAnimator.SetBool("DeixouPassar", deixouPassar);
            }*/
    }

    public void SetTrue()
    {
        bateu = true;
    }

    public bool GetTrue()
    {
        return bateu;
    }
}
