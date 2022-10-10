using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject head;
    bool fps = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (fps)
        {
            transform.position = head.transform.position;
            transform.forward = head.transform.forward;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime);
            transform.LookAt(target.transform.parent);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            fps = !fps;
        }

    }
}
