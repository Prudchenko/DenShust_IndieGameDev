using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{

    public GameObject[] pieces;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateCustomer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //void GenerateCustomer()
    //{
    //    Customer customer = new Customer();
    //
    //}

    IEnumerator GenerateCustomer()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        Customer customer = new Customer();
        CustGenerator.SetAppearance(customer);
        Instantiate<CustomerP, SpawnPointPos.position, Quaternion.identity>;
        StartCoroutine(GenerateCustomer());
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if()
    }
}
