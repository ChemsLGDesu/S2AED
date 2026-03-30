using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skills/Skill")]
public class Skill : ScriptableObject
{
    public int id;
    public string skillName;
    public int cost;
    public int requiredLevel;
}