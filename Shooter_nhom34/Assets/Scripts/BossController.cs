using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Spawnertime;
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("ActivateBoss", Spawnertime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ActivateBoss()
    {
            gameObject.SetActive(true);
    }
}
