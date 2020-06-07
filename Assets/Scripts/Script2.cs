using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script2 : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        float speed = 5.5f;

        Vector3 targetPosition = transform.position;

        Vector3 currentPosition = other.transform.position;

        if (Vector3.Distance(currentPosition, targetPosition) > 1.5f)
        {
            Vector3 directionOfTravel = targetPosition - currentPosition;
            directionOfTravel.Normalize();

            other.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World
                );
        }
        else
        {
            // Script Atack
        }
        other.transform.LookAt(transform);
    }
}