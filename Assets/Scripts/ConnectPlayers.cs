using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ConnectPlayers : MonoBehaviour
{
    public GameObject waitText;
    
    [SerializeField] private GameObject tank2Prefab;
    
    [Header("Tank1 UI")]
    [SerializeField] private Image bulletImage1;
    [SerializeField] private Image megaBulletImage1;
    [SerializeField] private TMP_Text damageText1;
    
    [Header("Tank2 UI")]
    [SerializeField] private Image bulletImage2;
    [SerializeField] private Image megaBulletImage2;
    [SerializeField] private TMP_Text damageText2;
    
    private PlayerInputManager _playerInputManager;
    
    private int _index;

    private void Awake()
    {
        Time.timeScale = 0f;
        _playerInputManager = GetComponent<PlayerInputManager>();
    }

    [UsedImplicitly]
    private void OnPlayerJoined()
    {
        ++_index;

        switch (_index)
        {
            case 1:
            {
                LinkTankUI(bulletImage1, megaBulletImage1, damageText1);
                break;
            }
            case 2:
            {
                LinkTankUI(bulletImage2, megaBulletImage2, damageText2);
                break;
            }
        }
        
        _playerInputManager.playerPrefab = tank2Prefab;
        
        if (_index != _playerInputManager.maxPlayerCount) return;
        
        GameTimer.GetTanks();
        
        Time.timeScale = 1f;
            
        waitText.SetActive(false);
    }

    private void LinkTankUI(Image bulletImage, Image megaBulletImage, TMP_Text damageText)
    {
        var tankManager = _playerInputManager.playerPrefab.GetComponent<TankManager>();

        tankManager.bulletImage = bulletImage;
        tankManager.megaBulletImage = megaBulletImage;
        tankManager.damageText = damageText;
    }
}