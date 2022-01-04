using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackCooldown = 0.85f;
    [SerializeField] private Transform hitpoint;
    [SerializeField] private GameObject[] knifes;
    private Animator animation;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        animation = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animation.SetTrigger("attack");
        cooldownTimer = 0;

        knifes[FindKnifes()].transform.position = hitpoint.position;
        knifes[FindKnifes()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindKnifes()
    {
        for (int i = 0; i < knifes.Length; i++)
        {
            if (!knifes[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
