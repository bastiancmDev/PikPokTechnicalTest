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
    }
    public virtual void ProccesAttack()
    {
        var damage = ManagerCentralizer.Instance.GamePlayContollerInstance.PlayerControllerRef.GetPlayerStats().GetDamageInTurn();
        AttackEnemy(damage);
    }
    public virtual void ProccesDefence()
    {
        var damage = ManagerCentralizer.Instance.GamePlayContollerInstance.PlayerControllerRef.GetPlayerStats().GetDamageInTurn();
        AttackEnemy(damage);
    }
    public virtual void AttackEnemy(int damage)
    {
        CurrentEnemy.reciveDamage(damage);
    }


}
