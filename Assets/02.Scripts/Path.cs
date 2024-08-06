using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] List<Transform> points;
    [SerializeField] Color lineColor = Color.red;

    void OnDrawGizmos()
    {
        Gizmos.color = lineColor;
        Transform[] pathTr = GetComponentsInChildren<Transform>();
        points = new List<Transform>();

        for (int i = 0; i < pathTr.Length; i++)
        {
            if (pathTr[i] != transform)
                points.Add(pathTr[i]);
        }

        for (int i = 0; i < points.Count; i++)
        {
            Vector3 curPoint = points[i].position;
            Vector3 pastPoint = Vector3.zero;

            if (i > 0)
                pastPoint = points[i - 1].position;

            else if (i == 0 && points.Count > 1)
                pastPoint = points[points.Count - 1].position;

            Gizmos.DrawLine(pastPoint, curPoint);
            Gizmos.DrawSphere(curPoint, 0.5f);
        }
    }
}
