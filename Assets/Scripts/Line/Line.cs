using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour
{
    private float _minRangeToDraw = 0.1f;
    private LineRenderer _lineRenderer;
    private List<Vector2> _points;
    public int PointsCount => _points.Count;

    public void Initialize(Vector2 firstPoint)
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _points = new List<Vector2>();
        AddPoint(firstPoint);
    }

    public void TryToAddPoint(Vector2 point)
    {
        if (Vector2.Distance(_points.Last(), point) > _minRangeToDraw)
            AddPoint(point);
    }

    public bool TryGetPoint(int id, out Vector3 point)
    {
        if (id < PointsCount)
        {
            point = new Vector3(_points[id].x, _points[id].y, 0);
            return true;
        }
        else
        {
            point = new Vector3(0,0,0);
            return false;
        }
    }

    private void AddPoint(Vector2 point)
    {
        _points.Add(point);
        _lineRenderer.positionCount = _points.Count;
        _lineRenderer.SetPosition(_points.Count - 1, point); 
    }
}
