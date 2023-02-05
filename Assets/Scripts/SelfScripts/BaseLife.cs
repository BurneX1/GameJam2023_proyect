using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseLife : MonoBehaviour
{
    [SerializeField]
    public int maxHealth;
    [SerializeField]
    public int actualHealth;


    public bool IsAlive => actualHealth >= 0;
    public event Action Damage = delegate { };
    private void Awake()
    {
        actualHealth = maxHealth;
    }
    public void ReduceLife(int damage)
    {
        damage = Mathf.Abs(damage);
        if (actualHealth > 0)
        {
            actualHealth = actualHealth - damage;
            Damage.Invoke();
        }
    }

    public void AddLife(int recovery)
    {
        recovery = Mathf.Abs(recovery);
        actualHealth = actualHealth + recovery;

        if (actualHealth > maxHealth)
        {
            actualHealth = maxHealth;
        }
    }

    public void IncreaseMaxLife(int plusLife)
    {
        plusLife = Mathf.Abs(plusLife);
        maxHealth += plusLife;
    }

}
