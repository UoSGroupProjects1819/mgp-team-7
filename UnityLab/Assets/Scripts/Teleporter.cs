using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    static int index = -1;
    public static string[] levels = new string[] { "Level1", "Level4", "Level3"};

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            index++;
            SceneManager.LoadScene(levels[index]);         
        }
    }
}
