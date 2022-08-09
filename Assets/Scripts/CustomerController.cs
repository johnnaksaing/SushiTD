using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public enum E_CustomerState 
    {
        Idle,
        Eating,
        Default
    }
    public E_CustomerState m_State = E_CustomerState.Idle;

    public Transform target;

    [Header("Attributes")]

    public float range = 5f;

    public float fireRate = 1f;
    private float fireCountDown = 0f;

    public float attackSpeed = 3f;

    public float StomachAmount = 5f;

    [SerializeField]
    Store m_Store;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject pfb_bullet;
    public Transform firePoint;

    public Vector3 EatingOffset;

    // Start is called before the first frame update
    void Start()
    {
        if (m_Store == null)
        {
            m_Store = GameObject.Find("Envs").GetComponent<Store>();
        }

        InvokeRepeating("UpdateTarget",1f,0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        if(target != null)
            Gizmos.DrawLine(transform.position,target.position);
    }
    public Vector3 chestOffset = new Vector3(0, -90, -90);
    // Update is called once per frame
    void Update()
    {
        if (m_State == E_CustomerState.Idle)
        {
            
            if (target == null)   
            {
                return;
            }

            if (target != null && Vector3.Distance(target.position, transform.position) > range)
                target = null;

            partToRotate.LookAt(target);
            partToRotate.rotation = partToRotate.rotation * Quaternion.Euler(chestOffset);

            /*
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(rotation.y, 0f,0f);
            */
            if (fireCountDown <= 0f) 
            {
                GetSushi();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;
        }
    }

    void GetSushi()
    {
        m_State = E_CustomerState.Eating;
        Debug.Log("Pew");
        EnemyScript Sushi = target.gameObject.GetComponent<EnemyScript>();

        Sushi.m_State = EnemyScript.E_SushiState.Taken;
        Sushi.speed *= 3;
        target.position = transform.position + EatingOffset;

        Eat();

    }
    void Eat() 
    {
        StartCoroutine("C_Eat");
    }

    IEnumerator C_Eat() 
    {
        yield return new WaitForSeconds(attackSpeed);

        StomachAmount = StomachAmount - target.gameObject.GetComponent<EnemyScript>().HP;
        
        Destroy(target.gameObject);
        m_State = E_CustomerState.Idle;

        if (StomachAmount < 0)
        {
            m_Store.AddStar(CountStar());

            Destroy(gameObject);
        }
    }

    float CountStar() 
    {
        return 4f;
    }

    void UpdateTarget() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestdistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestdistance)
            {
                shortestdistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestdistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else 
        {
            target = null;
        }
    }
}
