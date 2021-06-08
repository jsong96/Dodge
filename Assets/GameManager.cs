using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public GameObject gameOverText;
  public Text TimeText;
  public Text recordText;

  private float surviveTime;
  private bool isGameOver;

  // Start is called before the first frame update
  void Start()
  {
    surviveTime = 0;
    isGameOver = false;
  }

  // Update is called once per frame
  void Update()
  {
    if (!isGameOver)
    {
      surviveTime += Time.deltaTime;
      TimeText.text = "Time: " + (int)surviveTime;
    }
    else
    {
      if (Input.GetKeyDown(KeyCode.R))
      {
        SceneManager.LoadScene("SampleScene");
      }

      if (Input.GetKeyDown(KeyCode.Q))
      {
        Application.Quit();
      }
    }
  }

  public void EndGame()
  {
    isGameOver = true;
    gameOverText.SetActive(true);
    float bestTime = PlayerPrefs.GetFloat("Best Time");

    if (surviveTime > bestTime)
    {
      bestTime = surviveTime;

      PlayerPrefs.SetFloat("Best Time", bestTime);
    }

    recordText.text = "Best Time: " + (int)bestTime;
  }
}
