using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public float delay = 10f;
    private float delayTimer;

    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
       scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.name.Equals("Intro")){
            GameWirdGestartet();
        }
        
    }

    private void GameWirdGestartet()
    {
        //delayTimer = delayTimer + Time.deltaTime;
        //if (delayTimer > delay)
        //{
            SceneManager.LoadSceneAsync(2);
           // delayTimer = 0;
        //}

        
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

