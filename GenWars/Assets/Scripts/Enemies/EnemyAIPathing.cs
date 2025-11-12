using UnityEngine;
using UnityEngine.AI;

public class EnemyAIPathing : MonoBehaviour
{
    public Transform GeneratorTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(GeneratorTarget.position);
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
