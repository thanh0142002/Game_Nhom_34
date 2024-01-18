using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3
        (
            Mathf.Clamp(targetToFollow.position.x, -43f , 12f ),
            Mathf.Clamp(targetToFollow.position.y, -24f, 7.2f ),
            transform.position.z

        );
    }
}
