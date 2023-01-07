using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    [SerializeField] private int startAnime, endAnime;
    Animator transition;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        int i = 0;
        foreach (Transform anime in gameObject.transform)
        {
            anime.gameObject.SetActive(false);
            if (startAnime == i)
            {
                anime.gameObject.SetActive(true);
            }
            i++;
        }
    }
    public void LoadScene(int sceneNum)
    {
        Time.timeScale = 1;
        int i = 0;
        foreach (Transform anime in gameObject.transform)
        {
            anime.gameObject.SetActive(false);
            if (endAnime == i)
            {
                anime.gameObject.SetActive(true);
                transition = anime.GetComponent<Animator>();
            }
            i++;
        }
        StartCoroutine(LoadingScene(sceneNum));
    }
    IEnumerator LoadingScene(int sceneNum)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneNum);
    }
}
