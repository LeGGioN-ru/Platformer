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

    public void Deactivate()
    {
        _money.gameObject.SetActive(false);
    }
}
