using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private RectTransform rectTransform;

    public float rotateSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rectTransform != null)
        {
            Quaternion q = rectTransform.rotation;
            q.z += rotateSpeed;
            rectTransform.Rotate(Vector3.forward, rotateSpeed);
        }
        
    }
}
