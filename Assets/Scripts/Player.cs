using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image joystick;
    private Vector3 initialPositionJoystick;
    private Vector3 moveDirection = Vector3.zero;
    public float radio;
    CharacterController controller;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        initialPositionJoystick = joystick.GetComponent<RectTransform>().position;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >0 || Input.GetButton("Click_Raton"))
        {
            //Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            // moveDirection = new Vector3(Input.GetAxisRaw("Mouse X"), 0, Input.GetAxisRaw("Mouse Y")).normalized;
            moveDirection = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y) - new Vector3(initialPositionJoystick.x, 0, initialPositionJoystick.y);
            //moveDirection = transform.TransformDirection(moveDirection.normalized);
            if (moveDirection.magnitude <= 30)
            {
                joystick.GetComponent<RectTransform>().position = Input.mousePosition;
            }
            else
            {
                float angulo = Vector3.Angle(moveDirection, Vector3.right);
                if (Input.mousePosition.y < initialPositionJoystick.y)
                {
                    angulo = 360 - angulo;
                }
                float posX = radio * Mathf.Cos(Mathf.Deg2Rad * angulo);
                float posY = radio * Mathf.Sin(Mathf.Deg2Rad * angulo);
                joystick.GetComponent<RectTransform>().localPosition = new Vector3(posX, posY, 0);

                //print(angulo);
                //print(posX + " , " + posY);

            }
            print(moveDirection.magnitude);
            //moveDirection = moveDirection.normalized;
            moveDirection.Normalize();
            moveDirection *= speed;
            controller.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            joystick.GetComponent<RectTransform>().position = initialPositionJoystick;
        }
    }
}
