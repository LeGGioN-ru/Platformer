using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _amountMoneysMap;
    private int _currentAmountMoneys;
    private Money[] _moneys;

    public void Init(Money[] moneys)
    {
        _amountMoneysMap = moneys.Length;
        _moneys = moneys;

        for (int i = 0; i < _moneys.Length; i++)
        {
            _moneys[i].Reached += CollectMoney;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _moneys.Length; i++)
        {
            _moneys[i].Reached -= CollectMoney;
        }
    }

    private void CollectMoney()
    {
        _currentAmountMoneys++;

        if (_currentAmountMoneys == _amountMoneysMap)
        {
            Debug.Log("Вы победили!!!");
            return;
        }

        Debug.Log($"Вы собрали {_currentAmountMoneys}/{_amountMoneysMap} монет");
    }
}
