using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMenuController : MonoBehaviour
{
    // Start is called before the first frame update

    public Action<bool> ShowFightUIEvent { get; set; }
    public Action<bool> ShowInventoryUIEvent { get; set; }

    public Action<bool> ShowFinalPanelUIEvent { get; set; }
    public Action<PlayerStatsModel> UpdatePlayerStatsEvent { get; set; }
    public Action<PlayerStatsModel> UpdateEnemyStatsEvent { get; set; }


    public GameObject FigthUi;


    public void ShowFigthUI()
    {
        ShowFightUIEvent?.Invoke(true);
    }
    public void HideFigthUI()
    {
        ShowFightUIEvent?.Invoke(false);
    }
    public void ShowInventoryUI()
    {
        ShowInventoryUIEvent?.Invoke(true);
    }
    public void HideInventoryUI()
    {
        ShowInventoryUIEvent?.Invoke(false);
    }
    public void ShowLoseOrWonPanel(bool wonPanel)
    {
        ShowFinalPanelUIEvent?.Invoke(wonPanel);
    }


    public void UpdateFigthStats()
    {
        var playerStats = ManagerCentralizer.Instance.GamePlayContollerInstance.PlayerControllerRef.GetPlayerStats();
        PlayerStatsModel playerStatsModel = new PlayerStatsModel() { Damage = playerStats.GetBaseDamage(), Life = playerStats.GetBaseHealth() };
        UpdatePlayerStatsEvent?.Invoke(playerStatsModel);
        var enemyStats = ManagerCentralizer.Instance.GamePlayContollerInstance.CurrentEnemy.GetEnemyStats();
        UpdateEnemyStatsEvent?.Invoke(enemyStats);
    }

}
