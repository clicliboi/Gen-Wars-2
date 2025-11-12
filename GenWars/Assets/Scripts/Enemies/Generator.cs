using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private int generatorHealth = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int amount) {
        

        if (generatorHealth > 0)
        {
            generatorHealth -= amount;
            Debug.Log("Generator Health is " + generatorHealth);
        }
        else
        {
            Debug.Log("A generator has been destroyed!");
        }   
    }
}
