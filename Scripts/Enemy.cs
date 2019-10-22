using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy battle state
    public enum State
    {
        Walking,
        Attacking,
        Idling
    }

    // ?? Experimental ??
    public enum Status
    {
        Normal,
        Stunned,
        Slowed,
        Confused,
        Enraged
    }

    // ?? Experimental ??
    public enum DamageType
    {
        Normal,
        Water,
        Fire,
        Grass,
        Dark,
        Light,
        Physical,
        Magical,
        Pure
    }

    [SerializeField]
    State currentState;

    [Header("Stats")]
    [SerializeField]
    float maxHealth = 1;
    [SerializeField]
    float health         = 360;          // Health
    [SerializeField]
    float attack        = 15;           // Attack

    [SerializeField]
    float moveSpeed = 10.0f;       // Movement Speed of enemy

    /// <summary>
    /// Rename these to "distance"
    /// </summary>
    [SerializeField]
    float maxDistance = 15f;
    [SerializeField]
    float currentDistance = 15f;

    Animator anim;
    Rigidbody2D rb;

    [SerializeField]
    UnityEngine.UI.Image healthImage;
    [SerializeField]
    TMPro.TextMeshProUGUI distanceText;

    public GameObject enemy;

    private static bool isAttacking = false;
    private static bool isColliding = false;

    bool attackedOnce = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = enemy.GetComponent<Animator>();
        currentState = State.Walking;
        health = maxHealth;
    }

    // TO-DO: Fill enemy action gauge over time then make enemy do attack action 
    void Update()
    {
        if (currentDistance > 0)
        {
            currentDistance -= Time.deltaTime;
            UpdateDistanceText();
        }
        else if (!attackedOnce)
        {
            anim.SetTrigger("attack");
            attackedOnce = true;
        }

        //switch (currentState)
        //{
        //    case State.Walking:
        //        transform.Translate(Vector3.left * moveSpeed * 0.01f * Time.deltaTime, Space.World);
        //        anim.SetTrigger("walk");
        //        if (transform.position.x < 1.35) {  // Woop, melee range
        //            currentState = State.Attacking;
        //        }
        //        break;
        //    case State.Attacking:
        //        Debug.Log("ATTACKING");
        //        anim.SetTrigger("attack");
        //        if (transform.position.x > 1.35) {  // Woop, melee range
        //            anim.SetTrigger("walk");
        //            currentState = State.Walking;
        //        }
        //        break;
        //    case State.Idling:
        //        Debug.Log("IDLING");
        //        break;
        //}
    }

    public void IncreaseDistance(float amount)
    {
        currentDistance += amount;
        UpdateDistanceText();
    }

    public void ResetDistance()
    {
        currentDistance = maxDistance;
        UpdateDistanceText();
        attackedOnce = false;
    }

    public void UpdateDistanceText()
    {
        distanceText.text = currentDistance.ToString();
    }

    //private void OnEnable()
    //{
    //    
    //}

    // TO-DO, damage amount and type
    public void TakeDamage(float amount, DamageType type)
    {
        health -= amount;
        healthImage.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        gameObject.SetActive(false);
    }

    // Wtf not working >.>
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision");
        if (!isAttacking)
            isAttacking = true;
        isColliding = true;
        currentState = State.Attacking;
    }

    // Blah
    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("Collision Exit");
        isColliding = false;
    }

}




