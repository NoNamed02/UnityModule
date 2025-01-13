using System.Collections;
using System.Collections.Generic;
using Autohand;
using UnityEngine;

public class SnapToPosition : MonoBehaviour
{
    public Transform pos;              // 스냅 위치와 회전 설정
    public int findNumber;

    private void OnCollisionStay(Collision collision)
    {
        Grabbable grabbable = GetComponent<Grabbable>();
        if (grabbable != null && grabbable.IsHeld())
        {
            return;
        }

        if (collision.gameObject.CompareTag("PosSet") &&
        findNumber == collision.gameObject.GetComponent<SetSnapPosition>().paperNumber)
        {
            transform.position = pos.position;
            transform.rotation = pos.rotation;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false;            // 중력 비활성화
                rb.velocity = Vector3.zero;      // 선형 속도 초기화
                rb.angularVelocity = Vector3.zero; // 회전 속도 초기화
                rb.isKinematic = true;           // 물리 시뮬레이션 중지
            }

            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Grabbable>().enabled = false;
        }
    }
}
