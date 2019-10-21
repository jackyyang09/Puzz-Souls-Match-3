// To use:
//GameObject skillObject = GameObject.Find("Skill_Sword");
//Skill skill = skillObject.GetComponent<Skill>();
//skill.IncreaseCount(1); 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Improve the implementation of this in the future
/// </summary>
public class Skill : MonoBehaviour
{
    public Text txt; // assign it from inspector
    
    [SerializeField]
    int amount = 0;

    void Start()
    {
        txt.text = amount.ToString();
    }

    public int GetValue()
    {
        return amount;
    }

    public void IncreaseCount(int amt = 1) {
        amount += amt;
        txt.text = amount.ToString();
    }

    public void DecreaseCount(int amt = 1)
    {
        amount -= amt;
        txt.text = amount.ToString();
    }
}

