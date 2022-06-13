using UnityEngine;
using UnityEngine.UI;

public class mana : MonoBehaviour
{
    [SerializeField] private PlayerMana playerMana;
    [SerializeField] private Image currentmanaBar;

    private void Start()
    {
        currentmanaBar.fillAmount = playerMana.currentmanabar / 10;
    }
    private void Update()
    {
        currentmanaBar.fillAmount = playerMana.currentmanabar / 10;
    }
}