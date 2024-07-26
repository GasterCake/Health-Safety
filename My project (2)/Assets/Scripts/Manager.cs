using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject WinScreen;
    public bool BossRoom;
    // Start is called before the first frame update
    void Awake()
    {
        WinScreen.SetActive(false);
        Time.timeScale = 1;
        BossRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Win()
    {
        WinScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
