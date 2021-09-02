using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float panBorder = 5f;
    float panSpeed = 10f;
    public Vector2 panLimit;
    private float scrollSpeed = 300f;

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetMouseButton(1) && Player.instance.canMove == true)
        {
            transform.eulerAngles += 2f * new Vector3(x: -Input.GetAxis("Mouse Y"), y: Input.GetAxis("Mouse X"), z: 0f);
        }
        else if(Player.instance.canMove)
        {
            if (Input.mousePosition.y >= Screen.height - panBorder)
            {
                pos.z += panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.y <= panBorder)
            {
                pos.z -= panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x >= Screen.width - panBorder)
            {
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x <= panBorder)
            {
                pos.x -= panSpeed * Time.deltaTime;
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            pos.y -= scroll * scrollSpeed * Time.deltaTime;

            pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
            pos.y = Mathf.Clamp(pos.y, 5f, 20f);
            pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

            transform.position = pos;
        }

    }
}
