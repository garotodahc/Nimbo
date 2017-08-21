using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loadscreen : MonoBehaviour
{

    // Use this for initialization
    public AudioSource audio;

    public static string lastLevel = "";

    // Update is called once per frame
    public void ChangeToscene(string sceneToChange)
    {
        //Seto variável static para puder verificar se user clicou em repetir ou prosseguir level.
        StatusScript.levelToChange = sceneToChange;

        audio.Play();
        WaitForSeconds wait = new WaitForSeconds(audio.clip.length + 0.1f);

        //Application.LoadLevel(sceneToChange);
        SceneManager.LoadScene(sceneToChange);
    }
}