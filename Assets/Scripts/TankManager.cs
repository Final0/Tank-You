using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TankManager : MonoBehaviour
{
    [HideInInspector] public bool gameFinished;
    
    [HideInInspector] public Image bulletImage, megaBulletImage;
    [HideInInspector] public TMP_Text damageText;
    
    [Header("Tank Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float shootInterval;
    [SerializeField] private float megaShootInterval;
    
    [Header("Tank Components")]
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject wheels;
    [SerializeField] private GameObject tracks;
    [SerializeField] private GameObject hull;
    
    private int _damageCount;
    
    private Vector2 _movement, _rotation;

    private CharacterController _characterController;

    private Weapon _weapon;

    private float _shootTimer, _megaShootTimer;

    private bool _canShoot, _canMegaShoot;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    private void Start() => InitializeBulletsImages();

    private void Update()
    {
        if (gameFinished || Time.timeScale == 0f) return;
        
        TankMovement();
        TankRotation();
        
        ShootInterval();
        MegaShootInterval();
    }
    public void TakeDamage(int damage)
    {
        _damageCount += damage;

        damageText.text = _damageCount.ToString();
    }
    
    #region Tank Inputs
    [UsedImplicitly] private void OnMovement(InputValue value) => _movement = value.Get<Vector2>();
    [UsedImplicitly] private void OnRotation(InputValue value) => _rotation = value.Get<Vector2>();
    
    [UsedImplicitly] 
    private void OnShoot()
    {
        if (!_canShoot || gameFinished || Time.timeScale == 0f) return;
        
        _weapon.Shoot();
            
        _canShoot = false;
        bulletImage.fillAmount = 0f;
        _shootTimer = 0f;
    }

    [UsedImplicitly] 
    private void OnMegaShoot()
    {
        if (!_canMegaShoot || gameFinished || Time.timeScale == 0f) return;
        
        _weapon.MegaShoot();
            
        _canMegaShoot = false;
        megaBulletImage.fillAmount = 0f;
        _megaShootTimer = 0f;
    }
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

    private void ShootInterval()
    {
        if (_canShoot) return;
        
        _shootTimer += Time.deltaTime;
        
        bulletImage.fillAmount += 1 / shootInterval * Time.deltaTime;

        if (_shootTimer >= shootInterval) _canShoot = true;
    }
    
    private void MegaShootInterval()
    {
        if (_canMegaShoot) return;
        
        _megaShootTimer += Time.deltaTime;

        megaBulletImage.fillAmount += 1 / megaShootInterval * Time.deltaTime;

        if (_megaShootTimer >= megaShootInterval) _canMegaShoot = true;
    }

    private void InitializeBulletsImages()
    {
        bulletImage.fillAmount = 0f;
        megaBulletImage.fillAmount = 0f;
    }
}