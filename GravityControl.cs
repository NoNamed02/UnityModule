using System.Collections;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    public bool isGravity = false;
    public float waitSecond = 0.5f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(GravityToggleCoroutine());
    }

    IEnumerator GravityToggleCoroutine()
    {
        while (true)
        {
            isGravity = !isGravity;    
            //ResetVelocity();     
            if (isGravity) yield return new WaitForSeconds(waitSecond + 0.1f);
            else yield return new WaitForSeconds(waitSecond);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGravity = !isGravity;
        }

        if (isGravity)
        {
            ReverseGravity();
        }
        else
        {
            RestoreGravity();
        }
    }

    void ReverseGravity()
    {
        Physics.gravity = new Vector3(0, 9.81f, 0);
    }

    void RestoreGravity()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0); 
    }
}
