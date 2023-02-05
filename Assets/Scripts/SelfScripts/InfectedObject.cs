using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedObject : MonoBehaviour
{
    public BaseLife parasiteHealth;
    public GameObject parasite;
    public float fadeTime = 1f;
    public float infectionPercentage;

    void Start()
    {
        StartCoroutine(DoFadeIn(GetComponent<SpriteRenderer>()));
    }

    void Update()
    {
        infectionPercentage = 1.0f * parasiteHealth.actualHealth / parasiteHealth.maxHealth;

        if (parasiteHealth.actualHealth <= 0)
        {
            parasite.SetActive(false);
        }

        /*
        Debug.Log(parasiteHealth.actualHealth);
        Debug.Log(parasiteHealth.maxHealth);
        Debug.Log(infectionPercentage);
        */
    }

    IEnumerator DoFadeIn(SpriteRenderer _sprite)
    {
        Color tmpColor = _sprite.color;

        while (tmpColor.a > 0f)
        {
            tmpColor.a -= Time.deltaTime / fadeTime;
            _sprite.color = tmpColor;

            if (tmpColor.a <= infectionPercentage)
            {
                tmpColor.a = infectionPercentage;
            }

            yield return null;
        }

        _sprite.color = tmpColor;
    }
}
