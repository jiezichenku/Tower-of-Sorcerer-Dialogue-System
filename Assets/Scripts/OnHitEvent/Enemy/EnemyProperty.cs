using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyProperty
{

    public static int DamageCalculate(EnemyAttribute enemy)
    {
        BraverStatus braverStatus = BraverStatus.GetInstance();
        //Get braver attribute
        int braverHealth = braverStatus.getAttributes().GetAttribute("Health");
        int braverAttack = braverStatus.getAttributes().GetAttribute("Attack");
        int braverDefence = braverStatus.getAttributes().GetAttribute("Defence");
        int braverShield = braverStatus.getAttributes().GetAttribute("Shield");
        //Get enemy attribute
        int enemyHealth = enemy.Health;
        int enemyAttack = enemy.Attack;
        int enemyDefence = enemy.Defence;
        List<string> enemySkills = new List<string>(enemy.Skill);
        int enemyDamage = 0;

        //Skills affect on attributes
        int braverAttackDelta = 0;
        int braverDefenceDelta = 0;
        int braverShieldDelta = 0;
        double braverAttackRate = 1.0;
        double braverDefenceRate = 1.0;
        double braverShieldRate = 1.0;
        int enemyHealthDelta = 0;
        int enemyAttackDelta = 0;
        int enemyDefenceDelta = 0;
        double enemyHealthRate = 1.0;
        double enemyAttackRate = 1.0;
        double enemyDefenceRate = 1.0;

        //Skill implement
        if (enemySkills.Contains("Spark"))
        {
            enemyDamage += 100;
        }
        if (enemySkills.Contains("Blast"))
        {
            enemyDamage += 300;
        }
        if (enemySkills.Contains("Explode"))
        {
            enemyDamage += braverHealth / 3;
        }

        //Skills effect here
        int affectedBraverAttack = (int)(braverAttack * braverAttackRate) + braverAttackDelta;
        int affectedBraverDefence = (int)(braverDefence * braverDefenceRate) + braverDefenceDelta;
        int affectedBraverShield = (int)(braverShield * braverShieldRate) + braverShieldDelta;
        int affectedEnemyHealth = (int)(enemyHealth * enemyHealthRate) + enemyHealthDelta;
        int affectedEnemyAttack = (int)(enemyAttack * enemyAttackRate) + enemyAttackDelta;
        int affectedEnemyDefence = (int)(enemyDefence * enemyDefenceRate) + enemyDefenceDelta;

        //Battle logic
        double braverDamageRate = 1.0;
        double enemyDamageRate = 1.0;
        int enemyDamageDelta = 0;
        //If enemy cannot break braver's defence
        if (affectedEnemyAttack - affectedBraverDefence <= 0)
        {
            return 0;
        }
        //Get braver damage each turn
        int braverTurnDamage = (int)((affectedBraverAttack - affectedEnemyDefence)*braverDamageRate);
        if (braverTurnDamage <= 0) //Can not break enemy's defence
        {
            return -1;
        }
        //Calculate turns to defeat enemy
        int turn = affectedEnemyHealth / braverTurnDamage;
        if (affectedEnemyHealth % braverTurnDamage == 0)
        {
            turn -= 1;
        }
        //Calculate enemy damage deal to braver
        enemyDamage += (int)((affectedEnemyAttack - affectedBraverDefence) * enemyDamageRate) * turn + enemyDamageDelta - affectedBraverShield;
        if (enemyDamage < 0)
        {
            enemyDamage = 0;
        }
        return enemyDamage;
    }
}
