using B3NNY.Utils;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    public SkillManager skillManager;


    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        if (player != null)
            TestTakeDamage<Player>(player, 15);


        int simpleReturn = ReturnSimple(out string obj);
        Debug.Log(obj);

        int simpleReturn2 = ReturnSimple(out _);
    }


    public void BtnSelectSkill(Skill skill) // Método para seleccionar una habilidad
    {
        player.Target = skill;
        Debug.Log("Seleccionada: " + skill.skillName);

        // ✔ Mostrar descripción (out)
        SkillDescription(out string desc);
        Debug.Log(desc);

        // ✔ Validar si puede aprender
        bool canLearn = GameUtils.Validate(skill, s => player.level >= s.requiredLevel);

        if (canLearn)
        {
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

    public void ShowHighLevelSkills()
    {
        Skill[] highLevelSkills = GameUtils.Filter(
            skillManager.AllSkills.ToArray(),
            s => s.requiredLevel >= 3
        );

        foreach (var skill in highLevelSkills)
        {
            Debug.Log("Skill alta: " + skill.skillName);
        }
    }

    public void ExecuteSkills() // Ejecutar una acción para cada habilidad aprendida      
    {
        foreach (var skill in player.learnedSkills)
        {
            GameUtils.Process(skill, s =>
            {
                Debug.Log("Ejecutando: " + s.skillName);
            });
        }
    }

   
    public void FindSkill() // Buscar una habilidad específica en la lista de habilidades aprendidas
    {
        if (GameUtils.TryFind(skillManager.AllSkills.ToArray(), s => s.id == 1, out Skill found))
        {
            Debug.Log("Encontrada: " + found.skillName);
        }

        // ignorando resultado
        GameUtils.TryFind(skillManager.AllSkills.ToArray(), s => s.requiredLevel > 5, out _);
    }

    public void TestTakeDamage<T>(T damageable, int damage) where T : IDamageable
    {
        damageable.TakeDamage(damage);
    }

    public int SkillDescription(out string skillDescription)
    {
        skillDescription = "Skill Description: " + player.Target.SkillDescription;
        return 1;
    }
    public int GetPlayerLife(Player player)
    {
        return player.Life;
    }

    public int TestFunc(string value)
    {
        return 12;
    }

    public int ReturnSimple(out string value)
    {
        value = "Ayuda!!";
        return 1;
    }
}


