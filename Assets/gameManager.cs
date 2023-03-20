using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    [SerializeField] private float gameTime;
    [Header("開場倒數")]
    [SerializeField] private bool startCountDown;
    [Header("UI設置")]
    [SerializeField] private GameObject PauseUi;
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject countDownCanvas;
    private float timeCount;
    private bool isPausing;
    private void Awake()
    {
        instance = this;
    }
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
        countDownCanvas.SetActive(true);
        PlayerMove playerMove = FindObjectOfType<PlayerMove>();
        MpControl mpControl = FindObjectOfType<MpControl>();
        float tmp = mpControl.mpRecoverRate;

        mpControl.mpRecoverRate = 0;

        if(playerMove)
            playerMove.enabled = false;

        PlayerMoveV2 playerMoveV2 = FindObjectOfType<PlayerMoveV2>();
        if (playerMoveV2)
            playerMoveV2.enabled = false;

        yield return new WaitForSeconds(4);

        countDownCanvas.SetActive(false);
        mpControl.mpRecoverRate = tmp;


        if (playerMove)
            playerMove.enabled = true;

        if (playerMoveV2)
            playerMoveV2.enabled = true;

        startCountDown = false;
    }

    private void CountDown()
    {
        if (!startCountDown)
        {
            timeCount -= Time.deltaTime;
            if (timeCount < 30)
            {
                timerText.color = Color.red;
                if (timeCount <= 0)
                {
                    GameOver(1);
                    startCountDown = true;
                }

            }
        }


        //時間轉換
        int minutes = Mathf.FloorToInt(timeCount / 60f);
        int seconds = Mathf.FloorToInt(timeCount - minutes * 60);
        string timeString = string.Format("{0:0} : {1:00}", minutes, seconds);

        timerText.text = timeString;
    }
    public void GameOver(int winner)  //0->player A      1->player B
    {
        if (winner == 0)
        {
            SceneLoader.instance.LoadScene(3);
        }
        else
        {
            SceneLoader.instance.LoadScene(4);
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
