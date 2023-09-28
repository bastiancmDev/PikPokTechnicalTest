using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTemplate : MonoBehaviour
{
    [SerializeField]
    protected string Name { get; set; }
    [SerializeField]
    protected string Description { get; set; }
    [SerializeField]
    protected string Type { get; set; }
    [SerializeField]
    protected int Level { get; set; }
    [SerializeField]
    protected int Damage { get; set; }
    [SerializeField]
    protected int Life { get; set; }
   
    internal virtual void reciveDamage(int damage)
    {
        this.Life -= damage;
        if(Life <= 0 )
        {
            Die();
        }
    }

    public bool StillAlive()
    {
        return !(this.Life <= 0);
    }

    public void Start()
    {
        InitEnemy();
    }
    public virtual void InitEnemy()
    {
        Name = "ENEMY BASE";
        Description = "ENEMY BASE NO COMPLETED";
        Level = 1;
        Damage = 5;
        Life = 100;
    }

    public virtual void Attack()
    {
        ManagerCentralizer.Instance.GamePlayContollerInstance.CurrentFigthModality.ActionFromEnemy(ACTION_PLAYER_TYPE.ATACK);
    }

    public virtual void Die()
    {
        ManagerCentralizer.Instance.GamePlayContollerInstance.CurrentFigthModality.FinalizeFigthModality();
    }

    public virtual void InitTurn()
    {
        throw new System.NotImplementedException();
    }

    public virtual int GetEnemyDamage()
    {
        return this.Damage;
    }
    public virtual int UpdateLifeByDefence()
    {
        return Life += 5;
    }



    public PlayerStatsModel GetEnemyStats()
    {
        return new PlayerStatsModel() { Damage = Damage, Life = Life };
    }
}
