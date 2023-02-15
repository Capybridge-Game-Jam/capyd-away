using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public Button Play, Quit;
    // Start is called before the first frame update
    void Start()
    {
        MenuCanvas.SetActive(true);
        Play.onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene (sceneName: "INTRO");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
