using B3NNY.Utils;
using System.Collections.Generic;
using UnityEngine;

public class Player :MonoBehaviour, IDamageable
{
    public string Name;
    public int Life=100;
    public int level = 1;

    public Skill Target;
    public List<Skill> learnedSkills = new List<Skill>();

    void Start()
    {
        CheckSkillInfo(Target);
    }

    public void CheckSkillInfo(Skill target)  // Recibe una skill y muestra su información
    {
        if (target == null)
        {
            Debug.LogWarning("Skill es null");
            return;
        }

        Debug.Log("Nombre: " + target.skillName);
    }

    public void TryToLearnSkill(Skill target) // Recibe una skill y verifica si el jugador puede aprenderla
    {
        if (target == null) return;

        bool canLearn = GameUtils.Validate(target, s => level >= s.requiredLevel);

        if (canLearn)
        {
            if (learnedSkills.Contains(target))
            {
                Debug.Log("Ya aprendiste esta skill");
                return;
            }

            GameUtils.Process(target, s =>
            {
                learnedSkills.Add(s);
                Debug.Log("Aprendida: " + s.skillName);
            });
        }
        else
        {
            Debug.Log("No cumples requisitos para subir de nivel)");
        }
    }

    public void TryToFindSkill() // Verificar si el jugador ha aprendido la skill
    {
        Skill[] skillsArray = learnedSkills.ToArray();

        if (GameUtils.TryFind(skillsArray, s => s.skillName == Target.skillName, out Skill result))
        {
            Debug.Log("Encontrada: " + result.skillName);
        }
        else
        {
            Debug.Log("No encontrada");
        }
    }

    public void VerifyConditions() // Verificar si el jugador cumple las condiciones para aprender la skill
    {
        bool valid = GameUtils.Validate(Target, s => level >= s.requiredLevel);

        if (valid)
        {
            Debug.Log("Condiciones cumplidas para: " + Target.skillName);
        }
        else
        {
            Debug.Log("No cumple condiciones");
        }
    }

    public void LevelUp()
    {
        level++;
        Debug.Log("Nivel: " + level);

        if (level >= 5)
        {
            level = 5;
            Debug.Log("Nivel máximo");
        }
    }


    
    public void TakeDamage(int damage) // Recibe un valor de daño, lo resta a la vida del jugador y muestra la vida actual
    {
        damage = Random.Range(5, 15);
        Life -= damage;

        Debug.Log("Daño recibido: " + damage + " Vida actual: " + Life);
    }

    public void Move()
    {
        Debug.Log("Player se mueve");
    }
}

