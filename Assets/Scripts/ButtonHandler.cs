using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void restartGame()
    {
        BlockHandler.moveSpeed = 2f;
        PointHandler.points = 0;
        BlockHandler.fall = false;
        ResumeGame();
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    
    void PauseGame ()
    {
        Time.timeScale = 0;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
