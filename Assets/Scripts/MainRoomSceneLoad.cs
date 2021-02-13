using MathNet.Numerics.Distributions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainRoomSceneLoad : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject horse;
    public GameObject light;
    public GameObject character;
    public GameObject closedDoor;
    public GameObject openDoor;

    public LevelController lc;

    void OnEnable()
    {
        new Beta();
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {

        if (GameManager.instance.lastScene.name == "HorseRoom")
        {
            character.transform.position = horse.transform.position;
        }
        else if (GameManager.instance.lastScene.name == "LightRoom")
        {
            character.transform.position = light.transform.position;
        }
        else
        {
            character.transform.position = tutorial.transform.position;

        }

        if (GameManager.instance.hasHorse && GameManager.instance.hasToothbrush)
        {
            closedDoor.SetActive(false);
            openDoor.SetActive(true);
            lc.LanzaTexto(0);
        }

    }


}
