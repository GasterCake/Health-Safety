using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject winScreen;
    // Start is called before the first frame update
    void Awake()
    {
        winScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }

    public void Win() {
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
