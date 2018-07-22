using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class JeepMotion : MonoBehaviour
{
    float moveVertical;
    float moveHorizontal;
    float speed;
    public VirtualJoystick joystick;

    void Start()
    {
        speed = .1f;
    }

    void FixedUpdate()
    {
        if (joystick.Horizontal() != 0 || joystick.Vertical() != 0)
        {
            moveHorizontal = joystick.Horizontal();
            moveVertical = joystick.Vertical();
        }
        else if (Input.GetKey(KeyCode.UpArrow) ||
                 Input.GetKey(KeyCode.DownArrow) ||
                 Input.GetKey(KeyCode.LeftArrow) ||
                 Input.GetKey(KeyCode.RightArrow))
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveVertical = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moveVertical = -1;
            }
            else
            {
                moveVertical = 0;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveHorizontal = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveHorizontal = 1;
            }
            else
            {
                moveHorizontal = 0;
            }
        }
        else
        {
            moveVertical = 0;
            moveHorizontal = 0;
        }
        if (moveVertical != 0 || moveHorizontal != 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + moveHorizontal * speed,
                                                        gameObject.transform.position.y + moveVertical * speed);
            transform.eulerAngles = new Vector3(0.0f, 0.0f, (Mathf.Atan2(moveVertical, moveHorizontal) * (180 / Mathf.PI)) + 180);
        }
    }
}