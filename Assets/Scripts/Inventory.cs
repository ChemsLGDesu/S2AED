
using System.Collections.Generic;
using UnityEngine;


public class Inventory<T>
{
    public T CoreValue; 
    private List<T> inventory = new();

    /*public Inventory(T coreValue)
    {
        CoreValue = coreValue;
    }   */
    public void AddItem(T item)
    {
        inventory.Add(item);
        Debug.Log("You just add " + item);

    }
}
