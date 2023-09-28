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
    }
    public void Start()
    {
        InitEnemy();
    }
    public void InitEnemy()
    {
        Name = "ENEMY BASE";
        Description = "ENEMY BASE NO COMPLETED";
        Level = 1;
        Damage = 20;
        Life = 100;
    }

    public virtual void Attack()
    {
        ManagerCentralizer.Instance.GamePlayContollerInstance.CurrentFigthModality.ActionFromEnemy(ACTION_PLAYER_TYPE.ATACK);
    }

    public virtual void Die()
    {
        throw new System.NotImplementedException();
    }

    public virtual void InitTurn()
    {
        throw new System.NotImplementedException();
    }

    public virtual int GetEnemyDamage()
    {
        return this.Damage;
    }

    public PlayerStatsModel GetEnemyStats()
    {
        return new PlayerStatsModel() { Damage = Damage, Life = Life };
    }
}
