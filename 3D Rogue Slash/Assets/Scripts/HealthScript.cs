using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthScript : MonoBehaviour
{
    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;
    private EnemyController enemy_Controller;

    public float health = 100f;
    public bool is_Player, is_Enemy;
    private bool is_Dead;

    [SerializeField]
    public Slider progressBar;

    [SerializeField]
    public int maxProgress;

    // Start is called before the first frame update
    void Awake()
    {
        if (is_Enemy)
        {
            enemy_Anim = GetComponent<EnemyAnimator>();
            enemy_Controller = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();
        } else if (is_Player)
        {
            
        }
    }
    public void ApplyDamage(float damage)
    {
        if (is_Dead)
            return;
        health -= damage;

        if (is_Player)
        {
            
        } else if (is_Enemy)
        {
            if (enemy_Controller.Enemy_State == EnemyState.PATROL)
            {
                enemy_Controller.chase_Distance = 50f;
            }
        }
        if(health <= 0f)
        {
            PlayerDied();
            is_Dead = true;
        }
    }
    void PlayerDied()
    {
        if (is_Enemy)
        {
            navAgent.velocity = Vector3.zero;
            navAgent.isStopped = true;
            enemy_Controller.enabled = false;
            enemy_Anim.Dead();
            //inc progress
            progressBar.value++;
            if (progressBar.value == maxProgress)
            {
                //goto next scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (is_Player)
        {
            //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        }
        if (tag == "Player")
        {
            Invoke("RestartGame", 3f);
        }
        else
        {
            Invoke("TurnOffGameObject", 3f);
        }
    }
    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
}
