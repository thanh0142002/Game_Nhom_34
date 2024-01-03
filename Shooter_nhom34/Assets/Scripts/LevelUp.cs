using UnityEngine.UI;
using UnityEngine;

public class levelUp : MonoBehaviour
{
    public float maxExp = 1;
    public float cur_Exp = 0;
    public int cur_lvl;
    public Image expBar;

    public int bonusdamage;
    private void Start()
    {
        expBar = this.GetComponent<Image>();
    }
    private void Update()
    {

        if (expBar.fillAmount != cur_Exp)
        {
            expBar.fillAmount = cur_Exp;
        }
    }
    //khi enemy chet goi ham up level
    public void levelup()
    {
        cur_Exp += 0.2f / cur_lvl;
        if (cur_Exp >= maxExp)
        {
            cur_lvl++;
            cur_Exp = 0;
            bonusdamage = cur_lvl;

            expBar.fillAmount = cur_Exp;
        }
    }
}

