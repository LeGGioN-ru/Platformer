using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Money _moneyTemplate;

    private List<Transform> _moneysPoints;

    private void Start()
    {
        _moneysPoints = GetComponentsInChildren<Transform>().ToList();
        RemoveParentObject();

        Money[] moneys = new Money[_moneysPoints.Count];

        for (int i = 0; i < _moneysPoints.Count; i++)
        {
            moneys[i] = Instantiate(_moneyTemplate, _moneysPoints[i].transform);
        }

        _wallet.Init(moneys);
    }

    private void RemoveParentObject()
    {
        int parentObjectIndex = 0;
        _moneysPoints.RemoveAt(parentObjectIndex);
    }
}
