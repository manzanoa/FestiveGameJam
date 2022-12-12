using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentLauncher : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    GameObject present;

    private void FixedUpdate()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit raycastHit;

        if (Physics.Raycast(rayOrigin, out raycastHit))
        {
            if (raycastHit.collider != null)
            {
                Vector3 direction = raycastHit.point - transform.position;
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(present, spawnPoint.position, spawnPoint.rotation);
        }
    }

}
