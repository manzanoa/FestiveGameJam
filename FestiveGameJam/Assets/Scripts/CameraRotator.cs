using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    private float xRot, yRot;

    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        xRot = -1 * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        yRot = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Rotate(xRot, yRot, 0);

        float x;
        float y;

        if(transform.localEulerAngles.x > 180)
        {
            x = Mathf.Clamp(transform.localEulerAngles.x, 350, 360);
        }
        else
        {
            x = Mathf.Clamp(transform.localEulerAngles.x, 0, 35);
        }

        if(transform.localEulerAngles.y > 180)
        {
            y = Mathf.Clamp(transform.localEulerAngles.y, 260, 360);
        }
        else
        {
            y = Mathf.Clamp(transform.localEulerAngles.y, 0, 100);
        }

        transform.localEulerAngles = new Vector3(x, y, 0);
    }
}
