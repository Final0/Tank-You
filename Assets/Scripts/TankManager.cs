using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankManager : MonoBehaviour
{
    [HideInInspector] public int damageCount;
    
    [SerializeField] private float moveSpeed;
    
    [Header("Tank Components")]
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject wheels;
    [SerializeField] private GameObject tracks;
    [SerializeField] private GameObject hull;
    
    private Vector2 _movement, _rotation;

    private CharacterController _characterController;

    private Weapon _weapon;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        TankMovement();
        TankRotation();
    }

    #region Tank Inputs
    [UsedImplicitly] private void OnMovement(InputValue value) => _movement = value.Get<Vector2>();
    [UsedImplicitly] private void OnRotation(InputValue value) => _rotation = value.Get<Vector2>();
    [UsedImplicitly] private void OnShoot() => _weapon.Shoot();
    [UsedImplicitly] private void OnMegaShoot() => _weapon.MegaShoot();
    #endregion
    
    private void TankMovement()
    {
        if (_movement.magnitude > 1) _movement.Normalize();

        var movement = new Vector3(_movement.x, 0, _movement.y);
        _characterController.Move(movement * (moveSpeed * Time.deltaTime));
        
        if(_movement == Vector2.zero) return;
        
        var angle = - Mathf.Atan2(_movement.y, _movement.x) * Mathf.Rad2Deg + 90f;
        var rotation = new Vector3(0f, angle, 0f);

        hull.transform.rotation = Quaternion.Euler(rotation);
        tracks.transform.rotation = Quaternion.Euler(rotation);
        wheels.transform.rotation = Quaternion.Euler(rotation);
    }

    private void TankRotation()
    {
        if(_rotation == Vector2.zero) return;
        
        var angle = - Mathf.Atan2(_rotation.y, _rotation.x) * Mathf.Rad2Deg + 90f;
        var rotation = new Vector3(0f, angle, 0f);
        
        turret.transform.rotation = Quaternion.Euler(rotation);
    }
}