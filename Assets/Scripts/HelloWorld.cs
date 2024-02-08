using UnityEngine;

using GameInput;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.MoveEvent += OnMove;
        _inputReader.LookEvent += OnLook;
        _inputReader.FireEvent += OnFire;
        _inputReader.FireCancelEvent += OnFireCancel;
    }

    private void OnDisable()
    {
        _inputReader.MoveEvent -= OnMove;
        _inputReader.LookEvent -= OnLook;
        _inputReader.FireEvent -= OnFire;
        _inputReader.FireCancelEvent -= OnFireCancel;
    }

    private void OnMove(Vector2 moveInput)
    {
        Debug.Log($"Move Input: {moveInput}");
    }

    private void OnLook(Vector2 lookInput)
    {
        Debug.Log($"Look Input: {lookInput}");
    }

    private void OnFire()
    {
        Debug.Log("Fire Input");
    }

    private void OnFireCancel()
    {
        Debug.Log("Fire Cancel Input");
    }
}
