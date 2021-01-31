using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    [System.Serializable]
    public class Texto
    {
        public string textoo;
        public float duracion;
        public int indexSigTexto;
    }


    public Texto[] textos;
    public Texto textoPuerta;

    public GameObject canvasCharacter;
    private CharacterController2D character;
    public Text UIText;
    public AudioSource openAudioDoor;



    private void Awake()
    {
        //textos = new Texto[10];
        Application.targetFrameRate = 300;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        character = GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterController2D>();
        canvasCharacter.SetActive(false);
        //LanzaTexto(0);
    }

    public void LanzaTexto(int index)
    {
        StartCoroutine(MuestraTexto(index));
        character.aceptamosInput = false;
        canvasCharacter.SetActive(true);
    }


    private IEnumerator MuestraTexto(int index)
    {
        Debug.Log("Lanza texto");

        while (index > -1)
        {
            UIText.text = textos[index].textoo;
            yield return new WaitForSeconds(textos[index].duracion);
            index = textos[index].indexSigTexto;
        }
        canvasCharacter.SetActive(false);
        character.aceptamosInput = true;
    }



    public void loadScene(string scene)
    {
        GameManager.instance.LoadScene(scene);
    }

    public void playSound()
    {
        openAudioDoor.Play();
    }
}
