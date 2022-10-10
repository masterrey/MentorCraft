using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    GameObject ThingPrefab;
    [SerializeField]
    GameObject head;
    [SerializeField]
    GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

            
            RaycastHit hit;

        if (Physics.Raycast(head.transform.position, head.transform.forward, out hit, 100))
        {
            Debug.DrawLine(head.transform.position, hit.point, Color.green);
            Debug.Log(hit.collider.name);

            crosshair.transform.position = hit.point+hit.normal*0.01f;
            crosshair.transform.forward = hit.normal;

            if (Input.GetButtonDown("Fire1"))
            {

                Vector3 point = hit.point + hit.normal/2;
                Instantiate(ThingPrefab, new Vector3(Mathf.Round(point.x), Mathf.Round(point.y), Mathf.Round(point.z)), Quaternion.identity);
            }
        }
    }
}
