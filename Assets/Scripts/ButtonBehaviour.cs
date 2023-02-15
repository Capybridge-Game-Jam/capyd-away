using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    private bool isMenu = false;
    private int timescale = 1;
    public GameObject MenuCanvas;
    public Button Continue, Quit;
    // Start is called before the first frame update
    void Start()
    {
        MenuCanvas.SetActive(isMenu);
        Continue.onClick.AddListener(ContinueGame);
        Quit.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isMenu = !isMenu;
            timescale = (timescale == 1) ? 0 : 1;
            Time.timeScale = timescale;
            MenuCanvas.SetActive(isMenu);
        }
    }

    public void ContinueGame()
    {
        isMenu = !isMenu;
        timescale = (timescale == 1) ? 0 : 1;
        Time.timeScale = timescale;
        MenuCanvas.SetActive(isMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
