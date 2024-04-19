using UnityEngine;

public class Player : MonoBehaviour
{

    public TradeReputation TradeRep = TradeReputation.Bad;

    private void OnTriggerEnter (Collider other)
    {
        //Debug.Log("Вошли в триггер");

        if (other.gameObject.CompareTag("silverCoin"))
        {
            TradeRep = TradeReputation.Good;
            Debug.Log("Взяли серебряную монету");
            other.transform.GetComponent<Coin>().DestroyCoin();
        }
        if (other.gameObject.CompareTag("goldCoin"))
        {
            TradeRep = TradeReputation.Best;
            Debug.Log("Взяли золотую монету");
            other.transform.GetComponent<Coin>().DestroyCoin();
        }
    }

}

public enum TradeReputation
{
    Bad, //no trade
    Good, // trade fruits
    Best // trade armor
}

