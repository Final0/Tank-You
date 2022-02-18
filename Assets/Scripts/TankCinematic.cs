using JetBrains.Annotations;
using UnityEngine;

public class TankCinematic : MonoBehaviour
{
    [SerializeField] private GameObject crown1Image, crown2Image, ui, player1Text, player2Text;

    [SerializeField] private bool tank1;
    
    private Weapon _weapon;

    private Animator _animator;
    
    private void Awake()
    {
        _weapon = GetComponentInChildren<Weapon>();
        _animator = GetComponent<Animator>();
        
        _animator.Play("Move");
    }

    [UsedImplicitly] public void Shoot() => _weapon.CinematicShoot();

    [UsedImplicitly]
    public void PlayWin()
    {
        if(tank1 && crown1Image.activeSelf || !tank1 && crown2Image.activeSelf) _animator.Play("Win");
    }

    [UsedImplicitly]
    public void DisplayUI()
    {
        ui.SetActive(true);
        
        if(tank1) player1Text.SetActive(true);
        else player2Text.SetActive(true);
    }
}