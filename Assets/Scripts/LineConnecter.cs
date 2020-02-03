using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to control LineRenderer to draw a line constantly.
[RequireComponent(typeof(LineRenderer))]
public class LineConnecter : MonoBehaviour
{
    public Transform target;

    private LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (lineRenderer != null && target != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, target.position);
        }

    }

}
