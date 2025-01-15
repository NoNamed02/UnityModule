using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvisibleControl : MonoBehaviour
{
    public GameObject materialX;
    public GameObject materialZ;

    void Start()
    {
        Renderer paperRendererX = materialX.GetComponent<Renderer>();
        Renderer paperRendererZ = materialZ.GetComponent<Renderer>();
    }

    void Update()
    {
        if (materialX == null || materialZ == null) return;

        float rotationX = gameObject.transform.eulerAngles.x;
        float rotationZ = gameObject.transform.eulerAngles.z;

        if (rotationX > 180) rotationX -= 360;
        if (rotationZ > 180) rotationZ -= 360;

        // rotation.x가 -10에서 0 사이일 때 알파 값 조정
        if (rotationX >= -20f && rotationX <= 0f)
        {
            float alpha = Mathf.InverseLerp(-20f, 0f, rotationX); // -10~0 => 0~1로 변환
            SetMaterialAlpha(alpha, materialX);
        }

        if (rotationZ >= -20f && rotationZ <= 0f)
        {
            float alpha = Mathf.InverseLerp(-20f, 0f, rotationZ); // -10~0 => 0~1로 변환
            SetMaterialAlpha(alpha, materialZ);
        }
    }

    void SetMaterialAlpha(float alpha, GameObject material)
    {
        //Color color = paperMaterial.color;
        Color color = material.GetComponent<Renderer>().material.color;
        color.a = alpha;
        material.GetComponent<Renderer>().material.color = color;
    }
}