using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballSound;
    [SerializeField] private PlayerMana PlayerMana;

    private Animator anim;
    private Gerak playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Gerak>();
    }

    private void Update()
    {
        if (PlayerMana.currentmanabar>0.1f)
        {
            if (Input.GetKeyDown(KeyCode.T) && cooldownTimer > attackCooldown && playerMovement.canAttack())
                Attack();

            cooldownTimer += Time.deltaTime;
        }
        // buat nyoba mana nanti ubah aja lagi
        //if (Input.GetKeyDown(KeyCode.T) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        //    Attack();

        //cooldownTimer += Time.deltaTime;
    }
    public void attackFunction()
    {
        if (PlayerMana.currentmanabar > 0.1f)
        {
            if ( cooldownTimer > attackCooldown && playerMovement.canAttack())
                Attack();
            PlayerMana.manaPower(1);
            cooldownTimer += Time.deltaTime;
        }
    }
    public void Attack()
    {
        SoundManager.instance.PlaySound(fireballSound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}