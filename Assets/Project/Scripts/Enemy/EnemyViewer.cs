using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyViewer : Enemy
{
    [SerializeField] protected float _rotateTimer;

    private Coroutine _rotate;

    protected override void Start()
    {
        base.Start();
        _rotate = StartCoroutine(Rotate());
        _currentState = EnemyState.State.Idle;
    }

    protected override void Idle()
    {
        if (_rotate == null)
        {
            _rotate = StartCoroutine(Rotate());
        }
    }

    protected override void Chase()
    {
        if (_rotate != null)
        {
            StopCoroutine(_rotate);
            _rotate = null;
        }
        base.Chase();
    }

    private IEnumerator Rotate()
    {
        while (_currentState == EnemyState.State.Idle)
        {
            yield return new WaitForSeconds(_rotateTimer);
            if (_currentState == EnemyState.State.Idle)
            {
                transform.Rotate(0, 180, 0);
            }
        }
        _rotate = null;
    }
}
