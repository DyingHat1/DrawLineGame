using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private Line _lineTemplate;
    [SerializeField] private List<LineEnd> _lineEnds;
    [SerializeField] private LineSpawner _lineSpawner;

    private int _lineEndIdToDisable = 0;
    private Line _drawingLine;
    private Vector2 _mousePosition;

    public Line Line => _drawingLine;
    public event UnityAction LineDrew;

    private void OnEnable()
    {
        _lineSpawner.StartLine += OnStartLine;
    }

    private void OnDisable()
    {
        _lineSpawner.StartLine -= OnStartLine;
    }

    private void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            if (_drawingLine != null)
            {
                bool lineEnded = false;

                for (int i = 0; i < _lineEnds.Count; i++)
                {
                    if (_lineEnds[i].CurosrInTheEndZone)
                    {
                        _lineEndIdToDisable = i;
                        EndLine();
                        lineEnded = true;
                    }
                }

                if(lineEnded == false)
                    Destroy(_drawingLine.gameObject);
            }
        }

        if (_drawingLine != null)
            DrawLine(_mousePosition);
    }

    private void OnStartLine()
    {
        _drawingLine = Instantiate(_lineTemplate);
        _drawingLine.Initialize(_mousePosition);
    }

    private void DrawLine(Vector2 point)
    {
        _drawingLine.TryToAddPoint(point);
    }

    private void EndLine()
    {
        if (_drawingLine != null)
        {
            LineDrew?.Invoke();
            DisableAll();
        }
    }

    private void DisableAll()
    {
        _lineEnds[_lineEndIdToDisable].enabled = false;
        _lineSpawner.enabled = false;
        this.enabled = false;
    }
}
