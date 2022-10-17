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
    [SerializeField]
    private float forcaPulo = 10;
    [SerializeField]
    private float timePulo = 0.3f;
    float counttimePulo;
    float gravityResult=0;
    float anghead = 0;
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

        transform.Rotate(0, Input.GetAxis("Mouse X") * deltaT*180, 0);

        anghead += Input.GetAxis("Mouse Y") * deltaT*180;

        anghead = Mathf.Clamp(anghead, -75, 75);

        head.transform.rotation=Quaternion.Euler(anghead, head.transform.rotation.eulerAngles.y, head.transform.rotation.eulerAngles.z);




    }
    void FixedUpdate()
    {

        Vector3 movglobal = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), gravityResult, Input.GetAxis("Vertical")));
        caracter.Move(movglobal * velocidade);

        if (Input.GetButton("Jump")&& counttimePulo > 0)
        {
            gravityResult = timePulo * forcaPulo;
            counttimePulo -= Time.fixedDeltaTime;
        }

        if (Input.GetButtonUp("Jump") && counttimePulo > 0)
        {
            //gravityResult = 0;
            counttimePulo = 0;
        }

        if (caracter.isGrounded)
        {
            counttimePulo = 0.3f;
        }

        gravityResult = Mathf.Lerp(gravityResult, Physics.gravity.y, Time.fixedDeltaTime*0.5f);
    }
}
