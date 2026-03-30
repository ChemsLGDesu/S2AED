using B3NNY.Utils;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillManager", menuName = "Skills/SkillManager")]
public class SkillManager : ScriptableObject
{
    public Skill[] allSkills;  
}