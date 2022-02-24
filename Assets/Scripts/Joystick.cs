using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = GetComponent<RectTransform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            GetComponent<RectTransform>().position = Input.mousePosition;
            //print(Input.mousePosition);
            /*
            Vector3 joy = this.transform.position;
            print(joy);
            Vector3 moveJoy = mousePos - joy;
            //this.transform.position = moveJoy;
            this.anchoredPosition = moveJoy;
            */
        }
        else
        {
            GetComponent<RectTransform>().position = initialPosition;
        }
    }
}
