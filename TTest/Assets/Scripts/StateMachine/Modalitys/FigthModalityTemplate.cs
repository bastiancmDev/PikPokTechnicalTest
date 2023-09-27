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
        IsTurnOfPlayer = true;        
    }

    private void ProccesEnemyAttack()
    {
        int DamageOfEnemy = CurrentEnemy.GetEnemyDamage();
        ManagerCentralizer.Instance.GamePlayContollerInstance.PlayerControllerRef.GetPlayerStats().ReviceDamage(DamageOfEnemy);
    }

    private void ProccesEnemyDefence()
    {
        //throw new NotImplementedException();
    }

    public virtual void ProccesAttack()
    {
        var damage = ManagerCentralizer.Instance.GamePlayContollerInstance.PlayerControllerRef.GetPlayerStats().GetDamageInTurn();
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
        System.Random rnd = new System.Random();
        int movement = rnd.Next(0, 2);

        if( movement == 0)
        {
            ActionFromEnemy(ACTION_PLAYER_TYPE.ATACK);
        }
        else
        {
            ActionFromEnemy(ACTION_PLAYER_TYPE.DEFENCE);

        }

    }


}
