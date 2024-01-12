using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChucNangMenu : MonoBehaviour
{
    private bool isGamePaused = false;
    public void ChoiMoi()
    {
        SceneManager.LoadScene(1);
    }
    public void TroLai()
    {
        SceneManager.LoadScene(0);
    }
    public void Thoat() 
    {
        Application.Quit();
    }
    public void TamDung()
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }
    public void TiepTuc()
    {
        // Tiếp tục thời gian
        Time.timeScale = 1;
        isGamePaused = false;

    }

}
