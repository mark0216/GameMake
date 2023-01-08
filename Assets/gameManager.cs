using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField] private float gameTime;
    [Header("開場倒數")]
    [SerializeField] private bool startCountDown;
    [Header("UI設置")]
    [SerializeField] private GameObject PauseUi;
    [SerializeField] private Text timerText;
    private float timeCount;
    private bool isPausing;
    void Start()
    {
        timeCount = gameTime;
        if (startCountDown)
            StartCoroutine(ThreeTwoOne());
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
    IEnumerator ThreeTwoOne() //開場倒數
    {
        PlayerMove playerMove = FindObjectOfType<PlayerMove>();
        MpControl mpControl = FindObjectOfType<MpControl>();
        float tmp = mpControl.mpRecoverRate;

        mpControl.mpRecoverRate = 0;
        playerMove.enabled = false;
        yield return new WaitForSeconds(3);
        mpControl.mpRecoverRate = tmp;
        playerMove.enabled = true;
    }

    private void CountDown()
    {
        timeCount -= Time.deltaTime;
        if (timeCount < 30)
        {
            timerText.color = Color.red;
            if (timeCount <= 0)
            {

            }

        }

        //時間轉換
        int minutes = Mathf.FloorToInt(timeCount / 60f);
        int seconds = Mathf.FloorToInt(timeCount - minutes * 60);
        string timeString = string.Format("{0:0} : {1:00}", minutes, seconds);

        timerText.text = timeString;
    }
    private void GameOver(int winner)  //0->player A      1->player B
    {
        if (winner == 0)
        {

        }
        else
        {

        }
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
