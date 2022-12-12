using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField]
    float duration;

    private void Update()
    {
        transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        duration -= Time.deltaTime;

        if (duration <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
