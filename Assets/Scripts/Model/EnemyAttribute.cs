using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class EnemyAttribute
{
    public int EnemyID;
    public string EnemyName;
    public int Health;
    public int Attack;
    public int Defence;
    public int Gold;
    public int Experience;
    public List<string> Skill = new List<string>();
}
