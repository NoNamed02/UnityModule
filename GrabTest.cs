using System.Collections;
using System.Collections.Generic;
using Autohand;
using UnityEngine;

public class GrabTest : MonoBehaviour {
    public Transform palmTransform;
    public float maxGrabDistance = 10f;
    public float pullSpeed = 5f;

    public GameObject selectedObject;
    private bool drawGizmo = false;

    public Hand hand;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Y)) {
            Ray ray = new Ray(palmTransform.position, palmTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, maxGrabDistance))
            {
                selectedObject = hit.collider.gameObject;
                PullObject(selectedObject);
            }
            drawGizmo = true;
        }

        if (Input.GetKeyUp(KeyCode.Y)) {
            drawGizmo = false;
        }

        if (selectedObject != null && Vector3.Distance(palmTransform.position
        , selectedObject.transform.position) < 1)
        {
            hand.Grab();
        }
    }
    void PullObject(GameObject pullObject) {
        StartCoroutine(PullObjectTowardsHand(pullObject));
    }

    IEnumerator PullObjectTowardsHand(GameObject pullObject) {
        Rigidbody rb = pullObject.GetComponent<Rigidbody>();
        if (rb == null) {
            rb = pullObject.AddComponent<Rigidbody>(); // Rigidbody가 없으면 추가
            rb.useGravity = false; // 중력 비활성화
        }

        while (Vector3.Distance(pullObject.transform.position, palmTransform.position) > 0.1f) {
            Vector3 direction = (palmTransform.position - pullObject.transform.position).normalized;
            rb.velocity = direction * pullSpeed;

            yield return null;
        }

        rb.velocity = Vector3.zero;
        pullObject.transform.position = palmTransform.position;
    }



    void OnDrawGizmos() {
        if (drawGizmo) {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(palmTransform.position, palmTransform.position + palmTransform.forward * maxGrabDistance);

            if (selectedObject != null) {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(selectedObject.transform.position, 0.2f);
            }
        }
    }
}