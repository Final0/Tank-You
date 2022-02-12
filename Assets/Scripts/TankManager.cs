using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankManager : MonoBehaviour
{
    [SerializeField] private int damageCount;
    
    [SerializeField] private float moveSpeed;

    private Vector2 _movement, _rotation;

    private CharacterController _characterController;

    public void TakeDamage(int damage) => damageCount -= damage;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        TankMovement();
        TankRotation();
    }

    [UsedImplicitly] private void OnMovement(InputValue value) => _movement = value.Get<Vector2>();
    [UsedImplicitly] private void OnRotation(InputValue value) => _rotation = value.Get<Vector2>();
    
    private void TankMovement()
    {
        if (_movement.magnitude > 1) _movement.Normalize();

        var movement = new Vector3(_movement.x, 0, _movement.y);
        _characterController.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void TankRotation()
    {
        
    }
}