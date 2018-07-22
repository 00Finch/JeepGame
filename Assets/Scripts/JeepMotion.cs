using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class JeepMotion : MonoBehaviour
{

    float speed;
    public VirtualJoystick joystick;

    void Start()
    {
        speed = .1f;
    }

    void FixedUpdate()
    {
        float moveHorizontal = joystick.Horizontal();
        float moveVertical = joystick.Vertical();
        if (moveVertical != 0 || moveHorizontal != 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + moveHorizontal * speed,
                                                        gameObject.transform.position.y + moveVertical * speed);
            transform.eulerAngles = new Vector3(0.0f, 0.0f, (Mathf.Atan2(moveVertical, moveHorizontal) * (180 / Mathf.PI)) + 180);
        }

    }

}
