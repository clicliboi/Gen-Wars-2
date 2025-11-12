using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyLives = 10;

    public Generator generatorScript;

    private float attackTimer = 0;

    [SerializeField] private float attackWaitingTime = 1f;

    private bool canAttack = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > attackWaitingTime)
            {
                AttackingGenerator();

                attackTimer = 0;
            }
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Generator")
        {
            canAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Generator")
        {
            canAttack = false;
        }
    }

    private void AttackingGenerator()
    {
        Debug.Log("attack");
        generatorScript.Damage(5);
    }


}
