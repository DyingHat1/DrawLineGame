using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<LineDrawer> _drawers;
    [SerializeField] private LineDrawer _myDrawer;

    private PlayerMovement _mover;
    private Vector3[] _path;
    private int _linesDrew = 0;

    private void OnEnable()
    {
        foreach(LineDrawer drawer in _drawers)
        {
            drawer.LineDrew += OnAllLinesDrew;
        }

        _mover = GetComponent<PlayerMovement>();
    }

    private void OnDisable()
    {
        foreach (LineDrawer drawer in _drawers)
        {
            drawer.LineDrew -= OnAllLinesDrew;
        }
    }

    private void OnAllLinesDrew()
    {
        _linesDrew++;

        if (_linesDrew == _drawers.Count)
        {
            MakePath(_myDrawer.Line);
            _mover.MovePlayer(_path);
        }
    }

    private void MakePath(Line line)
    {
        _path = new Vector3[line.PointsCount];

        for (int i = 0; i < line.PointsCount; i++)
        {
            if (line.TryGetPoint(i, out Vector3 point))
                _path[i] = point;
        }
    }
}
