using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTemplate : MonoBehaviour
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected string Type { get; set; }
    protected int Level { get; set; }
    protected int Damage { get; set; }
    protected int Life { get; set; }

    public virtual void Attack()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Die()
    {
        throw new System.NotImplementedException();
    }

    public virtual void InitTurn()
    {
        throw new System.NotImplementedException();
    }
}
