using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public float currentmanabar;
    public float startMana;
    public float timespawnMana;
    private void Start()
    {
        currentmanabar = startMana;
    }
    void Update()
    {
        if (currentmanabar<startMana)
        {
            StartCoroutine(manaSpawn());
        }
        else
        {
            StopCoroutine(manaSpawn());
        }
    }
    public IEnumerator manaSpawn()
    {
        yield return new WaitForSeconds(timespawnMana);
        currentmanabar = Mathf.Clamp(currentmanabar + 0.01f, 0, startMana);

    }
    public void manaPower(float jumlahPakaiMana)
    {
        currentmanabar = Mathf.Clamp(currentmanabar - jumlahPakaiMana, 0,startMana );
    }
}
