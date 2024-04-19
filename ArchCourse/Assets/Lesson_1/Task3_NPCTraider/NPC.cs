using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{


    private Itrade TradeVar;

    public void Trade(TradeReputation rep)
    {
        Debug.Log("Привет, я торговец!");
        SetTradeVar(rep);
        TradeVar.Trade();
            
    }

    
    // :-( Не знаю как избавиться от этого свитча
    // по идее хочется чтобы как-то автоматически всё было
    private Itrade SetTradeVar (TradeReputation rep)
    {    
        switch (rep)
        {
            case TradeReputation.Bad:
                TradeVar = new TradeVar1();
                return TradeVar;
            case TradeReputation.Good:
                TradeVar = new TradeVar2();
                return TradeVar;
            case TradeReputation.Best:
                TradeVar = new TradeVar3();
                return TradeVar;
        } return null;
        
    }

    private void OnTriggerEnter(Collider other)
    {
    if ( other.gameObject.CompareTag("Player"))
        {                
            TradeReputation rep =  other.GetComponent<Player>().TradeRep;        
            Trade(rep);
        }

    }
}

public interface Itrade
{
    void Trade();
}