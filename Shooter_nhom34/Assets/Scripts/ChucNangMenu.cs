using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChucNangMenu : MonoBehaviour
{
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
}
