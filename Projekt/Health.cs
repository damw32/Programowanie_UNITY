using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] public float startHeal;
    public float currentHeal;
    private Animator animation;
    private bool dead;

    private void Awake()
    {
        currentHeal = startHeal;
        animation = GetComponent<Animator>();
    }

    public void TakeDamage (float damage)
    {
        currentHeal = Mathf.Clamp(currentHeal - damage, 0, startHeal);

        if(currentHeal > 0)
        {
            animation.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                animation.SetTrigger("dead");
                if(GetComponent<PlayerMovement>() != null)
                    GetComponent<PlayerMovement>().enabled = false;
                if (GetComponent<Demon>() != null)
                    GetComponent<Demon>().enabled = false;
                if (GetComponent<Boss>() != null)
                    GetComponent<Boss>().enabled = false;
                dead = true;
            }
        }
        if (currentHeal < 0.5 && GetComponent<PlayerMovement>() != null)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (currentHeal < 1 && GetComponent<Boss>() != null)
        {
            SceneManager.LoadScene("GameOverWin");
        }

    }

    public void AddHealth(float value)
    {
        currentHeal = Mathf.Clamp(currentHeal + value, 0, startHeal);
    }
}
