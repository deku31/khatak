using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GantiLevel : MonoBehaviour
{
 void OnTriggerEnter2D(Collider2D col)
    {
      if (col.gameObject.tag == "Player")
      {
        SceneManager.LoadScene(2);
      }
    }
}
