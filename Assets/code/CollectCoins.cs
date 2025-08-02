using UnityEngine;
using UnityEngine.UI;

public class CollectCoins : MonoBehaviour
{
    public Text coinText;
    public GameObject goToStationUI; // اسحب هنا UI اللي فيه رسالة "اذهب للمحطة"
    public int coinsToCollect = 3; // تم التعديل هنا من 5 إلى 3

    private int coinCount = 0;

    private void Start()
    {
        coinText.text = ": 0";
        goToStationUI.SetActive(false); // نخفي UI بالبداية
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            coinCount++;
            coinText.text = " " + coinCount.ToString();
            Destroy(other.gameObject);

            if (coinCount >= coinsToCollect)
            {
                goToStationUI.SetActive(true); // يظهر رسالة "اذهب للمحطة"
            }
        }
    }
}
