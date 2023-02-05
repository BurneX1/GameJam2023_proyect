using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyFlyMove : MonoBehaviour
{
    private BoxCollider2D c_coll;
    private int current;
    private int dir;
    private float timer = 0;

    public Vector2[] positions;
    private Vector2[] points = new Vector2[1];
    [Range(0.01f, 50)]
    public float movSpd;
    [Range(0.01f, 50)]
    public float waitTime;
    public bool cyclic;

    private void Awake()
    {
        SettPoints();
    }


    private void SettPoints()
    {
        points[0] = new Vector2(transform.position.x, transform.position.y);
        for (int i = 0; i < positions.Length; i++)
        {
            points = points.Concat(new Vector2[] { new Vector2(transform.position.x + positions[i].x, transform.position.y + positions[i].y) }).ToArray();
        }
    }
    private void StopTimer()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            timer = 0;
            NextPoint();
        }
    }

    public void Move()
    {
        if (new Vector2(transform.position.x, transform.position.y) != points[current])
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, points[current], movSpd * Time.deltaTime);
            gameObject.transform.position = pos;
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), points[current]) < 0.05)
            {
                gameObject.transform.position = points[current];
            }
        }
        else
        {
            StopTimer();
        }
    }
    public void NextPoint()
    {
        if (current >= points.Length - 1 && cyclic == false)
        {
            dir = -1;
        }
        else if (current <= 0)
        {
            dir = 1;
        }

        int next = (current + dir) % points.Length;
        if (points[next].x > points[current].x)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }

        current = next;
    }

    private int pathSideSwitch = 1;
    public void TemporalPath(Vector2 posOne, Vector2 posTwo)
    {
        Vector2 goAhead;
        if(pathSideSwitch > 0)
        {
            goAhead = posOne;
        }
        else
        {
            goAhead = posTwo;
        }

        Vector2 pos = Vector2.MoveTowards(transform.position, goAhead, movSpd * Time.deltaTime);
        gameObject.transform.position = pos;
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), goAhead) < 0.05)
        {
            gameObject.transform.position = goAhead;
            pathSideSwitch = pathSideSwitch * -1;
        }

        if (posOne.x > posTwo.x)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * pathSideSwitch, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * pathSideSwitch *-1, transform.localScale.y);
        }
    }
    public void ForceSetCurrent(int num)
    {
        current = num;
    }




    //-------------------Draw&Visual----------------------//

    private void OnDrawGizmos()
    {

        Gizmos.color = new Color(0, 1, 1, 0.12f);
        Vector2 befPos;
        Vector2 aftPos;

        if (Application.isPlaying)
        {
            befPos = points[0];
            for (int i = 0; i <= positions.Length; i++)
            {
                Gizmos.DrawCube(points[i], gameObject.GetComponent<BoxCollider2D>().bounds.size);
                if (i - 1 >= 0)
                {
                    befPos = points[i - 1];
                }
                Gizmos.DrawLine(points[i], befPos);
                if (i + 1 > positions.Length)
                {
                    aftPos = points[0];
                    Gizmos.DrawLine(points[i], aftPos);
                }

            }
        }
        else
        {
            befPos = transform.position;
            for (int i = 0; i < positions.Length; i++)
            {
                if (i - 1 >= 0)
                {
                    befPos = new Vector2(transform.position.x + positions[i - 1].x, transform.position.y + positions[i - 1].y);
                }
                Gizmos.DrawLine(new Vector2(transform.position.x + positions[i].x, transform.position.y + positions[i].y), befPos);
                if (i + 1 >= positions.Length)
                {
                    aftPos = transform.position;
                    Gizmos.DrawLine(new Vector2(transform.position.x + positions[i].x, transform.position.y + positions[i].y), aftPos);
                }
                Gizmos.DrawCube(new Vector2(transform.position.x + positions[i].x, transform.position.y + positions[i].y), gameObject.GetComponent<BoxCollider2D>().bounds.size);
            }
        }



    }
}
