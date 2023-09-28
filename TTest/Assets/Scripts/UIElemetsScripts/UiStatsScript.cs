using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiStatsScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text _playerDamage;
    [SerializeField]
    private Text _playerLife;

    [SerializeField]
    private Text _currentEnemyDamage;
    [SerializeField]
    private Text _currentEnemyLife;
    void Start()
    {
        ManagerCentralizer.Instance.UiMenuControllerInstance.UpdatePlayerStatsEvent += UpdatePlayerStats;
        ManagerCentralizer.Instance.UiMenuControllerInstance.UpdateEnemyStatsEvent += UpdateCurrentEnemyStats;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerStats(PlayerStatsModel playerStatsModel)
    {
        _playerDamage.text = playerStatsModel.Damage.ToString();
        _playerLife.text = playerStatsModel.Life.ToString();
    }

    public void UpdateCurrentEnemyStats(PlayerStatsModel playerStatsModel)
    {
        _currentEnemyDamage.text = playerStatsModel.Damage.ToString();
        _currentEnemyLife.text = playerStatsModel.Life.ToString();
    }
}
