using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankManager : MonoBehaviour
{
    [SerializeField] private int damageCount;
    
    [SerializeField] private float moveSpeed;

    private Vector2 _movement;

    private CharacterController _characterController;

    public void TakeDamage(int damage) => damageCount -= damage;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    [UsedImplicitly] private void OnMovement(InputValue value) => _movement = value.Get<Vector2>();
    
    private void PlayerMovement()
    {
        if (_movement.magnitude > 1) _movement.Normalize();

        _characterController.Move(new Vector3(_movement.x, 0, _movement.y) * (moveSpeed * Time.deltaTime));
        
        /*if(_movement.magnitude != 0)
            _weapon.transform.forward = new Vector3(_movement.x, 0, _movement.y);*/
    }
}