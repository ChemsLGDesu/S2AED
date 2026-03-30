using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillManager", menuName = "Skills/SkillManager")]
public class Skill : ScriptableObject
{
    public string SkillDescription;
    public int id;
    public string skillName;
    public int requiredLevel;
}