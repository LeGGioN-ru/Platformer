using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Money))]
public class MoneyDeactivator : MonoBehaviour
{
    private Money _money;

    private void Start()
    {
        _money = GetComponent<Money>();
    }

    public void Execute()
    {
        _money.gameObject.SetActive(false);
    }
}
