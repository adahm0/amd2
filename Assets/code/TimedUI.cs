using UnityEngine;
using System.Collections;

public class ShowUIAfterTime : MonoBehaviour
{
    public GameObject uiPanel;

    void Start()
    {
        StartCoroutine(ShowUI());
    }

    IEnumerator ShowUI()
    {
        yield return new WaitForSeconds(60f);
        uiPanel.SetActive(true);
    }
}
