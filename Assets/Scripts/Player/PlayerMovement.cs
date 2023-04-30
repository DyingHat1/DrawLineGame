using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AnimationClip _animation;

    private Animator _animator;
    private float _secondsToPassPath = 3f;
    private Tweener _tween;

    public event UnityAction Win;
    public event UnityAction Lose;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void MovePlayer(Vector3[] path)
    {
        _animator.Play(_animation.name);
        _tween = transform.DOPath(path, _secondsToPassPath, PathType.Linear).SetEase(Ease.Linear).OnComplete(OnWin);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _animator.StopPlayback();
            _tween.Kill();
            Lose?.Invoke();
        }
    }

    private void OnWin()
    {
        _animator.StopPlayback();
        Win?.Invoke();
    }
}
