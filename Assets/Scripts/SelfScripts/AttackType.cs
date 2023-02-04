using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Attack")]
public class AttackType : ScriptableObject
{
    public string atackName;
    public Vector2 posVariation;
    public Vector2 hitRadio;
    public AnimatorOverrideController overrAnim;
    public int dmg;

}
