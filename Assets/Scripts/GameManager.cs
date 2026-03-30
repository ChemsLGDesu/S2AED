using B3NNY.Utils;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public SkillManager skillManager;
    void Start()
    {
        if (player != null)
            TestTakeDamage<Player>(player, 15);


        int simpleReturn = ReturnSimple(out string obj);
        Debug.Log(obj);

        int simpleReturn2 = ReturnSimple(out _);

        // Habilidades

        Debug.Log("!tienes todas las habilidades");

        foreach (var skill in skillManager.allSkills)
        {
            Debug.Log("Skill: " + skill.skillName);


            bool canLearn = GameUtils.Validate(skill, s => player.level >= s.requiredLevel);  // que confirme si puede aprender

            if (canLearn)
            {
                Debug.Log("Puede aprender");

                // Si APRENDE LA skill
                GameUtils.Process(skill, s =>
                {
                    if (!player.learnedSkills.Contains(s))
                    {
                        player.learnedSkills.Add(s);
                        Debug.Log("Aprendida: " + s.skillName);
                    }
                });
            }
            else
            {
                Debug.Log("Nivel insuficiente");
            }
        }

        Debug.Log("habilidad aprendida");


        foreach (var skill in player.learnedSkills)  // Recorrer habilidades aprendidas
        {
            //EjECUTA SKILL
            GameUtils.Process(skill, s =>
            {
                Debug.Log("Ejecutando: " + s.skillName);
            });
        }

        // ttryFind
        if (GameUtils.TryFind(skillManager.allSkills, s => s.id == 1, out Skill found))
        {
            Debug.Log("Encontrada: " + found.skillName);
        }

        // out 
        GameUtils.TryFind(skillManager.allSkills, s => s.cost > 100, out _);
    }


    public int GetPlayerLife(Player player)
    {
        return player.Life;
    }

    public int TestFunc(string value)
    {
        return 12;
    }

    public void TestTakeDamage<T>(T value, int damage) where T : IDamageable
    {
        value.TakeDamage(damage);
    }

    public int ReturnSimple(out string value)
    {
        value = "Ayuda!!";
        return 1;
    }
}
