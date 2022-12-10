using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private List<Transform> checkpoints;

    Transform start, end;
    Vector3 targetDirection;
    Quaternion targetRotation;
    private int counter = 0;
    private bool arrived = false;
    private bool doneRotating = false;
    private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        end = checkpoints[counter];

        targetDirection = end.position - transform.position;

        targetRotation = Quaternion.LookRotation(targetDirection);


        //Start the rotating coroutine
        //StartCoroutine(LookAtCheckpoint(start, end));
    }

    // Update is called once per frame
    void Update()
    {
        targetDirection = end.position - transform.position;
        targetRotation = Quaternion.LookRotation(targetDirection);

        transform.position = Vector3.MoveTowards(transform.position, end.position, speed * Time.deltaTime);

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, speed * Time.deltaTime, .0f);

        transform.rotation = Quaternion.LookRotation(newDirection);

        if(transform.position == end.position)
        {
            counter++;

            if(counter < checkpoints.Count)
            {
                end = checkpoints[counter];
            }
            else
            {
                Debug.Log("End of path");
            }
            
        }



        //if(doneRotating)
        //{
        //    doneRotating = false;
        //    StartCoroutine(MoveToCheckpoint(start, end));
        //}

        //if(arrived)
        //{
        //    arrived = false;
        //    if(counter < checkpoints.Count)
        //    {
        //        //coroutine for rotating
        //        start = transform;
        //        end = checkpoints[counter];
        //        StartCoroutine(LookAtCheckpoint(start, end));
        //    }
        //}


    }

    //Moving coroutine here
    IEnumerator MoveToCheckpoint(Transform start, Transform end)
    {
        float timeElapsed = 0;
        float duration = 5;

        while(timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(start.position, end.position, Mathf.SmoothStep(0, 1, timeElapsed / duration));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = end.position;
        counter++;
        arrived = true;
    }

    //Rotating coroutine here
    IEnumerator LookAtCheckpoint(Transform start, Transform end)
    {
        float timeElapsed = 0;
        float duration = 5;

        Quaternion direction = Quaternion.LookRotation(end.position - start.position);

        while (timeElapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(start.rotation, direction, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = direction;
        doneRotating = true;
    }


}
