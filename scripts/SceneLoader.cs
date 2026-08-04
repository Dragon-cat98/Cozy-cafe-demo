using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    string SceneNeeded;
    string SceneToLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneLoad(string SceneToLoad)
    {
        //loads the scene that is passed as a parameter
        SceneManager.LoadScene(SceneToLoad);
    }

    public void Quit()
    {
        //quits
        Application.Quit();
        Debug.Log("Quitted");
    }
}
