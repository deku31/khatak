using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jatuh : MonoBehaviour
{
[SerializeField]Transform spawnPoint;



void OnCollisionEnter2D(Collision2D col)
{
    if(col.transform.CompareTag("Player"))
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

}
