using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StatusScript : MonoBehaviour
{

    private int chuva, raio, lencol, subpontos, tick = 60, count = 0;
    public Text statusVida, statusChuva, statusRaio, statusLencol, statusPontos;
    public GameObject spriteLencol;
    public AudioSource audioLifeUp;
    public AudioSource audioLifeOver;
    public string completeScene;

    public static int limitePontos;
    public static int pontos = 0, partialPontos = 0;
    public static int vida = 3, partialVida = 3;
    /*partialPontos é utilizado para contabilizar a pontuação do round e subtrair, caso user vá em "Tentar novamente"*/
    public static string thisLevel = "", levelToChange = "";


    // Use this for initialization 0.024f
    void Start()
    {        
        chuva = 0;
        raio = 0;
        lencol = 50;
        if (SceneManager.GetActiveScene().name.Equals("GameScene") || SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            pontos = 0;
            vida = 3;
        }

        partialVida = vida;
        partialPontos = pontos;
        limitePontos = GetLimitePontuacao(SceneManager.GetActiveScene().name);
        
        subpontos = 0;

        statusVida.text = vida.ToString();
        statusRaio.text = raio.ToString();
        statusChuva.text = chuva.ToString();
        statusPontos.text = pontos.ToString() + " (" + limitePontos.ToString() + ")";
        statusLencol.text = lencol.ToString() + " %";
        
        

        //PontuacaoScheme();
    }

    //private static int GetLimitePontucao(string level)
    //{
    //    switch (level)
    //    {
    //        case "GameScene":
    //            return 2000;
    //        case "":
    //            return 2000;
    //        case "GameScene2":
    //            return 4500;
    //        case "GameScene3":
    //            return 7500;
    //    }
    //    return 0;
    //}

    private static int GetLimitePontuacao(string level) 
    {
        if(level.Equals("GameScene")||level.Equals(""))
        {
            return 2000;
        }
        else 
        {
            return ((pontos / 100) * 100) + 2000;
        }
    }
    // Update is called once per frame
    void Update()
    {
        subpontos++;
        float tempLencol = spriteLencol.transform.position.y;

        if (tempLencol != -3.4f - ((100 - lencol) * 0.024f))
        {
            if (tempLencol > -3.4f - ((100 - lencol) * 0.024f))
            {
                spriteLencol.transform.position = new Vector3(-0.05f, tempLencol - 0.003f, 0f);
            }
            else
            {
                spriteLencol.transform.position = new Vector3(-0.05f, tempLencol + 0.003f, 0f);
            }
        }

        if (vida < 0) 
        {
            statusVida.text = "0";
            if (!audioLifeOver.isPlaying)
            { 
                audioLifeOver.Play(); 
            }
            count++;
            if (count >= tick) 
            {
                //Application.LoadLevel("GameOverScene");
                vida = partialVida;
                pontos = partialPontos;
                SceneManager.LoadScene("Over" + SceneManager.GetActiveScene().name);
            }
        }
        
        if (subpontos >= 10)
        {
            subpontos -= 10;
            pontos++;
            //partialPontos++;
        }

        if (lencol < 0)
        {
            if (vida == 0)
            {
                lencol = 0;
                statusLencol.text = lencol.ToString() + " %";
                spriteLencol.transform.position = new Vector3(-0.05f, -3.4f - ((100 - lencol) * 0.024f), 0f);

                //Application.LoadLevel("GameOverScene");
                vida = partialVida;
                pontos = partialPontos;
                SceneManager.LoadScene("Over" + SceneManager.GetActiveScene().name);
            }
            else
            {
                audioLifeOver.Play();
                vida--;
                lencol = 50;

                statusVida.text = vida.ToString();
                statusLencol.text = lencol.ToString() + " %";
                spriteLencol.transform.position = new Vector3(-0.05f, -3.4f - ((100 - lencol) * 0.024f), 0f);

            }
        }
        else
        {
            if (lencol > 100)
            {
                if (lencol >= 120)
                {
                    audioLifeUp.Play();
                    vida++;
                    lencol = 50;

                    statusVida.text = vida.ToString();
                    statusLencol.text = lencol.ToString() + " %";
                    spriteLencol.transform.position = new Vector3(-0.05f, -3.4f - ((100 - lencol) * 0.024f), 0f);
                }
                else
                {
                    statusLencol.text = "100 %";
                    spriteLencol.transform.position = new Vector3(-0.05f, -3.4f, 0f);
                }
            }
            else
            {
                statusLencol.text = lencol.ToString() + " %";
                //spriteLencol.transform.position = new Vector3(-0.05f, -3.62f - ((100 - lencol) * 0.024f), 0f);
            }
        }
        statusPontos.text = pontos.ToString() + " (" + limitePontos.ToString() + ")";

        if (pontos >= limitePontos)
        {
            //limitePontosAntigo = limitePontos;
            //Application.LoadLevel(completeScene);
            
            SceneManager.LoadScene(completeScene);
        }
    }

    public int GetVida()
    {
        return vida;
    }
    public void SetVida(int valor)
    {
        vida += valor;
    }
    public int GetChuva()
    {
        return chuva;
    }
    public void SetChuva(int novoChuva)
    {
        chuva = novoChuva;
    }
    public int GetRaio()
    {
        return raio;
    }
    public void SetRaio(int novoRaio)
    {
        raio = novoRaio;
    }
    public int GetLencol()
    {
        return lencol;
    }
    public void SetLencol(int valor)
    {
        lencol = lencol + valor;
    }
    public int GetPontos()
    {
        return pontos;
    }
    public void SetPontos(int valor)
    {
        pontos += valor;
    }
    public int GetLP()
    {
        return limitePontos;
    }
    public void SetLP(int valor)
    {
        limitePontos += valor;
    }


    //private static void PontuacaoScheme()
    //{
    //    if (thisLevel.Equals(levelToChange))
    //    {
    //        fixScore();
    //        resetPartialScore();

    //        limitePontos = GetLimitePontuacao(thisLevel);

    //    }
    //    else
    //    {
    //        thisLevel = levelToChange;
    //        resetPartialScore();
    //    }
    //}
    //private static void fixScore()
    //{
    //    pontos -= partialPontos;

    //}
    //private static void resetPartialScore()
    //{
    //    partialPontos = 0;

    //}


}
