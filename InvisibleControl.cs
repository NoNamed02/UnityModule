using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleControl : MonoBehaviour
{
    public GameObject Paper; // Paper GameObject

    private Material paperMaterial;

    void Start()
    {
        Renderer paperRenderer = Paper.GetComponent<Renderer>();
        paperMaterial = paperRenderer.material;
    }

    void Update()
    {
        if (Paper == null || paperMaterial == null) return;

        float rotationX = Paper.transform.eulerAngles.x;

        if (rotationX > 180)
        {
            rotationX -= 360;
        }

        // rotation.x가 -10에서 0 사이일 때 알파 값 조정
        if (rotationX >= -10f && rotationX <= 0f)
        {
            float alpha = Mathf.InverseLerp(-10f, 0f, rotationX); // -10~0 => 0~1로 변환
            SetMaterialAlpha(alpha);
        }
        else if (rotationX < -10f)
        {
            SetMaterialAlpha(0f); // 완전히 투명
        }
        else if (rotationX > 0f)
        {
            SetMaterialAlpha(1f); // 완전히 불투명
        }
    }

    void SetMaterialAlpha(float alpha)
    {
        if (paperMaterial == null) return;

        Color color = paperMaterial.color;
        color.a = alpha;
        paperMaterial.color = color;
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVLamp : MonoBehaviour
{
    public GameObject Paper; // Paper GameObject
    public GameObject ReferenceObject; // 기준이 되는 GameObject

    private Material paperMaterial;

    void Start()
    {
        if (Paper != null)
        {
            Renderer paperRenderer = Paper.GetComponent<Renderer>();
            paperMaterial = paperRenderer.material;
        }
    }

    void Update()
    {
        if (Paper == null || ReferenceObject == null || paperMaterial == null) return;

        Vector3 paperForward = Paper.transform.forward;
        Vector3 referenceForward = ReferenceObject.transform.forward;

        float angle = Vector3.SignedAngle(referenceForward, paperForward, Vector3.right);

        if (angle >= -10f && angle <= 0f)
        {
            float alpha = Mathf.InverseLerp(-10f, 0f, angle); // -10~0 => 0~1로 변환
            SetMaterialAlpha(alpha);
        }
        else if (angle < -10f)
        {
            SetMaterialAlpha(0f); // 완전히 투명
        }
        else if (angle > 0f)
        {
            SetMaterialAlpha(1f); // 완전히 불투명
        }
    }

    void SetMaterialAlpha(float alpha)
    {
        if (paperMaterial == null) return;

        Color color = paperMaterial.color;
        color.a = alpha;
        paperMaterial.color = color;
    }
}
*/
