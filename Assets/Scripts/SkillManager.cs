using B3NNY.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SkillManager", menuName = "Skills/SkillManager")]

public class SkillManager : ScriptableObject
{

    [SerializeField] List<Skill> skillList;
    public List<Skill> AllSkills => skillList;



    public void ShowSkillName<T>(T skill) where T : Skill  // Función para mostrar los dataos de la  habilidad
    {
        Debug.Log("Nombre: " + skill.skillName);
    }


    public bool ValidateSkill<T>(Player sender, T target, Func<Player, T, bool> condition, out T result) where T : Skill // Función genérica para validar si un jugador puede usar una habilidad según una condición
    {
        if (sender == null || target == null || condition == null)
        {
            result = default;
            return false;
        }

        if (condition(sender, target))
        {
            result = target;
            return true;
        }

        result = default;
        return false;
    }

  

    public bool TryLearnSkill<T>(Player sender, T target, out T result) where T : Skill // Función  para intentar aprender una habilidad
    {
        if (sender == null || target == null)
        {
            result = default;
            return false;
        }

        if (sender.level >= target.requiredLevel)
        {
            result = target;
            return true;
        }

        result = default;
        return false;
    }

    
    public bool TryFindSkill<T>(IEnumerable<T> array, Func<T, bool> condition, out T result) // Función para intentar encontrar una habilidad en una colección según una condición
    {
        if (array == null || condition == null)
        {
            result = default;
            return false;
        }

        foreach (var item in array)
        {
            if (condition(item))
            {
                result = item;
                return true;
            }
        }

        result = default;
        return false;
    }


    public void ExecuteSkill<T>(T skill, Action<T> action) where T : Skill // Función para ejecutar una acción con una habilidad, verificando que la habilidad y la acción no sean nulas
    {
        if (skill == null || action == null) return;
        action(skill);
    }
}



