using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject gameObjectUILose;
    public GameObject gameObjectUIWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {
        gameObjectUILose.SetActive(true);
    }
    public void gameWin()
    {
        gameObjectUIWin.SetActive(true);
    }
}
