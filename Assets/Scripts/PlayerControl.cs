using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float deltaT;
    [SerializeField]
    private float velocidade = 10;
    [SerializeField]
    GameObject head;
    [SerializeField]
    CharacterController caracter;


    // Start is called before the first frame update
    void Start()
    {
        caracter = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        deltaT = Time.deltaTime;

        //transform.localPosition += new Vector3(0, 0, Input.GetAxis("Vertical") * deltaT);
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Horizontal") * deltaT * 180, 0);

        //transform.Translate(new Vector3(0, caracter.SimpleMove(new Vector3(Input.GetAxis("Horizontal")));
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal") * deltaT * velocidade, 0, 0));



        transform.Rotate(0, Input.GetAxis("Mouse X") * deltaT*180, 0);

        head.transform.Rotate( Input.GetAxis("Mouse Y") * deltaT * 180,0, 0);




    }
    void FixedUpdate()
    {

        Vector3 movglobal = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        caracter.SimpleMove(movglobal * velocidade);

    }
}
