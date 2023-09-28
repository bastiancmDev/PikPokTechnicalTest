using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FigthModalityTemplate 
{
    protected bool IsTurnOfPlayer;
    protected EnemyTemplate CurrentEnemy;
    public FigthModalityTemplate()
    {
        IsTurnOfPlayer = true;
    }
    public virtual void InitFigthModality(EnemyTemplate currentEnemy)
    {
        CurrentEnemy = currentEnemy;
        SwitchTurn();
    }
    public virtual void ActionFromPlayer(ACTION_PLAYER_TYPE actionType)
    {
        if (!IsTurnOfPlayer)
        {
            return;
        }
        switch (actionType)
        {
            case ACTION_PLAYER_TYPE.DEFENCE:
                ProccesDefence();
                break;
            case ACTION_PLAYER_TYPE.ATACK:
                ProccesAttack();
                break;
        }
        IsTurnOfPlayer = false;
        TurnOfEnemy();
        SwitchTurn();
    }

    public virtual void ActionFromEnemy(ACTION_PLAYER_TYPE actionType)
    {
        if (IsTurnOfPlayer)
        {
            return;
        }
        switch (actionType)
        {
            case ACTION_PLAYER_TYPE.DEFENCE:
                ProccesEnemyDefence();
                break;
            case ACTION_PLAYER_TYPE.ATACK:
                ProccesEnemyAttack();
                break;
        }
              
    }

    private void ProccesEnemyAttack()
    {
        int DamageOfEnemy = CurrentEnemy.GetEnemyDamage();
        ManagerCentralizer.Instance.GamePlayContollerInstance.PlayerControllerRef.GetPlayerStats().ReviceDamage(DamageOfEnemy);
        var healtPlayer = ManagerCentralizer.Instance.GamePlayContollerInstance.PlayerControllerRef.GetPlayerStats().GetBaseHealth();
        if (healtPlayer <= 0)
        {
            ManagerCentralizer.Instance.UiMenuControllerInstance.ShowLoseOrWonPanel(false);
        }
    }

    private void ProccesEnemyDefence()
    {
         CurrentEnemy.UpdateLifeByDefence();
        
    }

    public virtual void ProccesAttack()
    {
        var damage = ManagerCentralizer.Instance.GamePlayContollerInstance.PlayerControllerRef.GetPlayerStats().GetBaseDamage();
        AttackEnemy(damage);
    }
    public virtual void ProccesDefence()
    {        
        DefencePlayer();
    }
    public virtual void AttackEnemy(int damage)
    {
        CurrentEnemy.reciveDamage(damage);
    }

    public virtual void DefencePlayer()
    {
        ManagerCentralizer.Instance.GamePlayContollerInstance.PlayerControllerRef.GetPlayerStats().DefenceMovement();
    }


    public virtual void TurnOfEnemy()
    {
        ManagerCentralizer.Instance.GamePlayContollerInstance.SwtichTurnFunctionDelay(AttackFromEnemyCalculator);
    }    


    public void AttackFromEnemyCalculator()
    {
        if (CurrentEnemy != null &&  CurrentEnemy.StillAlive())
        {
            System.Random rnd = new System.Random();
            int movement = rnd.Next(0, 2);

            if (movement == 0)
            {
                ActionFromEnemy(ACTION_PLAYER_TYPE.ATACK);
            }
            else
            {
                ActionFromEnemy(ACTION_PLAYER_TYPE.DEFENCE);

            }
            IsTurnOfPlayer = true;
            SwitchTurn();
        }       
    }

    public void SwitchTurn()
    {
        ManagerCentralizer.Instance.UiMenuControllerInstance.UpdateFigthStats();
    }



    public virtual void FinalizeFigthModality()
    {
        CurrentEnemy = null;
        ManagerCentralizer.Instance.GamePlayContollerInstance.OnFinalizeFigth();
    }

}
