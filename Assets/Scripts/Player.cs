using System.Collections.Generic;
using UnityEngine;

public class Player :MonoBehaviour, IDamageable
{
    public string Name;
    public int Life;
    public int level = 1;
    public List<Skill> learnedSkills = new List<Skill>();

    public void Move()
    {
        Debug.Log("Player is moving");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Recibi daño!");
    }
}

