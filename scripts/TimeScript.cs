using UnityEngine;

public class TimeScript : MonoBehaviour
{
    /*created to make sure that when going beck to the main menu through the pause menu the time didn't freeze*/
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
