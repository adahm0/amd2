using UnityEngine;

public class PlayerTriggerUI : MonoBehaviour
{
    public GameObject stationUI; // اسحب الـ UI هنا في الـ Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Station"))
        {
            stationUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Station"))
        {
            stationUI.SetActive(false);
        }
    }
}
