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
    [SerializeField]
    float velocity = 2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (fps)
        {
            transform.position = head.transform.position;
            transform.forward = head.transform.forward;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.smoothDeltaTime* velocity);
            transform.LookAt(target.transform.parent);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            fps = !fps;
        }

    }
}
