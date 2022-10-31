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

    [SerializeField]
    GameObject[] objects;

    [SerializeField]
    Inventario inventario;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            i++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            i--;
        }

        i = Mathf.Clamp(i, 0, objects.Length);
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
                if (inventario.ChecktIten(i))
                {
                    inventario.GetIten(i);
                    Instantiate(objects[i], new Vector3(Mathf.Round(point.x), Mathf.Round(point.y), Mathf.Round(point.z)), Quaternion.identity);
                }
            }

            if (Input.GetButtonDown("Fire2"))
            {
                if (hit.collider.CompareTag("Cubo"))
                {
                    Destroy(hit.collider.gameObject);

                    inventario.SetIten(i,1);
                }
                   
            }
        }
    }
}
