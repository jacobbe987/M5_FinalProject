using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cmCamera;
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    [SerializeField] private float _recenterSpeed;

    private bool _isCentering;

    private void Update()
    {
        CamMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isCentering = true;
        }

        if (_isCentering)
        {
            transform.position = Vector3.Lerp(transform.position, _player.position, _recenterSpeed * Time.deltaTime);
            
        }

        if (Vector3.Distance(transform.position, _player.position) < 0.1)
        {
            _isCentering = false;
        }
    }

    private void CamMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 direction= forward*v + right*h;

        transform.position += direction * _speed * Time.deltaTime;
    }
}
