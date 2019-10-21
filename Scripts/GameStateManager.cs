using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages enemy interactions, will also spawn enemies each "floor"
/// </summary>
public class GameStateManager : MonoBehaviour
{
    /// <summary>
    /// </summary>
    [SerializeField]
    Enemy currentEnemy;

    [SerializeField]
    Skill attackSkill;

    public static GameStateManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            // A unique case where the Singleton exists but not in this scene
            if (instance.gameObject.scene.name == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackEnemy()
    {
        if (attackSkill.GetValue() <= 0) return;
        attackSkill.DecreaseCount();
        currentEnemy.TakeDamage(10, Enemy.DamageType.Normal); // Debug number lol, use an actual value in the future
    }

    /// <summary>
    /// Temporary
    /// </summary>
    /// <returns></returns>
    public Enemy GetEnemy()
    {
        return currentEnemy;
    }
}
