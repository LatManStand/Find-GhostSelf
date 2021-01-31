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



    private void OnLevelWasLoaded(int level)
    {
        if (level == 4)
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


}
