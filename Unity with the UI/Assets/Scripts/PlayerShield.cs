using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public float cooldownTime;

    public float shieldCharge;

    private bool isReady = true;

    public GameObject shield;

    IEnumerator shieldControl()
    {
        shield.SetActive(true);
        yield return new WaitForSecondsRealtime(shieldCharge);
        shield.SetActive(false);
        yield return new WaitForSecondsRealtime(cooldownTime);
        isReady = true;
    }

    private void Update()
    {
        if (isReady)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isReady = false;
                StartCoroutine(shieldControl());
            }
        }
        
    }
}
