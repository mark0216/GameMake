using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseUi;
    [SerializeField] private float gameTime;
    private float timeCount;
    private bool isPausing;
    void Start()
    {
        timeCount = gameTime;
    }

    void Update()
    {
        CountDown();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPausing)
                _Pause();
            else
                Resume();
        }
    }

    private void CountDown()
    {
        timeCount -= Time.deltaTime;
    }
    public void _Pause()
    {
        isPausing = true;
        PauseUi.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        isPausing = false;
        PauseUi.SetActive(false);
        Time.timeScale = 1;
    }
    public void Reload()
    {
        SceneLoader.instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ToMenu()
    {
        SceneLoader.instance.LoadScene(0);
    }

}
