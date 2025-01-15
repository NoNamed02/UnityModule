using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour
{
    public float forceStrength = 0.1f;
    public float torqueStrength = 0.1f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = 5;
        rb.mass = 4;
        if (rb != null)
        {
            rb.useGravity = false;

            Vector3 randomForce = new Vector3(
                Random.Range(-forceStrength, forceStrength),
                Random.Range(-forceStrength, forceStrength),
                Random.Range(-forceStrength, forceStrength)
            );
            rb.AddForce(randomForce, ForceMode.Impulse);

            Vector3 randomTorque = new Vector3(
                Random.Range(-torqueStrength, torqueStrength),
                Random.Range(-torqueStrength, torqueStrength),
                Random.Range(-torqueStrength, torqueStrength)
            );
            rb.AddTorque(randomTorque, ForceMode.Impulse);
        }
    }
}
