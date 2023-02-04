using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
public class AttackHabilityManager : MonoBehaviour
{
    public AttackType[] aviableAttacks;
    public GameObject[] showItemBox;
    // Start is called before the first frame update
    void Start()
    {
        ShowAviables();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void AddAttack(AttackType atk)
    {

        AttackType[] addValue = { atk };
        if (aviableAttacks.Length == 0)
        {
            aviableAttacks = addValue;
        }
        else
        {

            aviableAttacks = aviableAttacks.Concat(addValue).ToArray();

        }
    }

    public void ShowAviables()
    {

        for(int i = 0; i < showItemBox.Length; i++)
        {
           
            if (i< aviableAttacks.Length)
            {
                showItemBox[i].GetComponent<Image>().sprite = aviableAttacks[i].icon;
            }
            else
            {
                showItemBox[i].SetActive(false);
            }
        }
    }

    public void Rote()
    {
        AttackType[] addValue = aviableAttacks.Where((e, i) => i != 0).ToArray(); ;
        if (aviableAttacks.Length == 0)
        {
            return;
        }
        else
        {
            AttackType[] toadArray = { aviableAttacks[0] };
            addValue = addValue.Concat(toadArray).ToArray();

            aviableAttacks = addValue;

        }

        ShowAviables();
    }


}
