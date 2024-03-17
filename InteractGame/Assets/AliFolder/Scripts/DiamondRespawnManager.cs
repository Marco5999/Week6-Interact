using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondRespawnManager : MonoBehaviour
{
    public static DiamondRespawnManager Instance; // Singleton instance

    void Awake()
    {
        // Ensure only one instance of DiamondRespawnManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartRespawnCoroutine(GameObject diamond, float delay)
    {
        StartCoroutine(RespawnDiamond(diamond, delay));
    }

    IEnumerator RespawnDiamond(GameObject diamond, float delay)
    {
        // Wait for the specified respawn time
        yield return new WaitForSeconds(delay);

        // Reactivate the diamond GameObject
        diamond.SetActive(true);
    }
}
