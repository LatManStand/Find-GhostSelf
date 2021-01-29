using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text txt;
    public Text money;

    public int moneys;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
        moneys = 10;
        money.text = "Money: " + moneys;
    }


    public void Win()
    {
        if (Time.timeScale != 0.0f)
        {
            Time.timeScale = 0.0f;
            txt.text = "Congratulations! You won!";
        }
    }

    public void Lose()
    {
        if (Time.timeScale != 0.0f)
        {
            Time.timeScale = 0.0f;
            txt.text = "You lost";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Map1");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AddMoney(int mon)
    {
        moneys += mon;
        money.text = "Money: " + moneys;
    }

}
