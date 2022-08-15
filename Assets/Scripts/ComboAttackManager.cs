using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttackManager : MonoBehaviour
{
    public GameObject[] ComboSushies;
    public GameObject[] NormalInputs;
    //Queue<E_Skill> q;
    List<E_Skill> q;
    /// <summary>
    /// Combo Commands : 다른 데에 일괄적으로 저장해 두고 콤보매니저가 참조해서 쓰면 더 좋을 것 같다.
    /// </summary>
    public enum E_Skill 
    {
        punch = 0, //A
        kick = 1,//D
        
        
        MAX = 999999
    }
    E_Skill[] pkk = { E_Skill.punch, E_Skill.kick , E_Skill.kick};
    E_Skill[] ppk = { E_Skill.punch, E_Skill.punch, E_Skill.kick };
    E_Skill[] pkp = { E_Skill.punch, E_Skill.kick, E_Skill.punch};
    E_Skill[] kppp = { E_Skill.kick, E_Skill.punch, E_Skill.punch, E_Skill.punch };

    E_Skill[][] ComboCommands;
    readonly int min_skill_count = 3;

    //end of Combo commands
    public GameObjectPool<DestoryBehavior> normalPool_0;
    public GameObjectPool<DestoryBehavior> normalPool_1;

    void Awake()
    {
        normalPool_0 = new GameObjectPool<DestoryBehavior>(0, () =>
        {
            var obj = Instantiate(NormalInputs[0], transform);
            DestoryBehavior b = obj.GetComponent<DestoryBehavior>();
            b.shef = this;
            b.m_Skill = E_Skill.punch;
            obj.SetActive(true);
            return b;
        });
        normalPool_1 = new GameObjectPool<DestoryBehavior>(0, () =>
        {
            var obj = Instantiate(NormalInputs[1], transform);
            DestoryBehavior b = obj.GetComponent<DestoryBehavior>();
            b.shef = this;
            b.m_Skill = E_Skill.kick;
            obj.SetActive(true);
            return b;
        });
    }

    void Start()
    {
        
        //q = new Queue<E_Skill>();
        q = new List<E_Skill>();
        current_commands = new List<E_Skill>();
        ComboCommands = new E_Skill[][] { ppk, pkp, pkk, kppp };
        
        string str = "combos : \n";
        for (int i = 0; i < ComboCommands.Length; i++)
        {
            for (int j = 0; j < ComboCommands[i].Length; j++)
            {
                str += ComboCommands[i][j];
            }
            str += '\n';
        }
        Debug.Log(str);
    }

    float time = 0f;
    public float ComboValidTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        HandleInput();

        if (time > ComboValidTime)
        {
            //Debug.Log(q);
            time = 0; 
        }
    }
    E_Skill e = E_Skill.MAX;
    void HandleInput() 
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            time = 0;
            e = E_Skill.punch;
            q.Add(e);

            if (!SpawnSkill())
            {
                SpawnMelee(e);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            time = 0;
            e = E_Skill.kick;
            q.Add(e);

            if (!SpawnSkill())
            {
                SpawnMelee(e);
            }
        }

    }
    void SpawnMelee(E_Skill e) 
    {
        if (e == E_Skill.MAX) 
            return;

        if (e == E_Skill.punch)
        {
            DestoryBehavior go = normalPool_0.Get();
            go.gameObject.SetActive(true);
            go.Reuse();
            go.transform.position = transform.position + new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
        }
        else if (e == E_Skill.kick) 
        {
            DestoryBehavior go = normalPool_1.Get();
            go.gameObject.SetActive(true);
            go.Reuse();
            go.transform.position = transform.position + new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
        }
    }

    List<E_Skill> current_commands;
    bool SpawnSkill() 
    {
        
        if (q.Count < min_skill_count)
            return false;

        current_commands = q;

        int idx = 999999;
        bool bHit = false;

        for (int i = 0; i < ComboCommands.Length && !bHit; i++)
        {
            if (current_commands.Count < ComboCommands[i].Length)
                continue;

            for (int input_offset = 0; input_offset <= current_commands.Count - ComboCommands[i].Length && !bHit; input_offset++)
            {
                bool b = true;
                int j = 0;
                for (; j < ComboCommands[i].Length && b; j++)
                {
                    b &= ComboCommands[i][j] == current_commands[j+ input_offset];
                }
                if (j < ComboCommands[i].Length)
                    b = false;

                if (b)
                {
                    bHit = true;
                    idx = i;
                    break;
                }
            }
        }

        if (bHit)
        {
            Instantiate(ComboSushies[idx], transform.position + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5)), Quaternion.identity);
            time = 0;
            current_commands.Clear();
        }

        q = current_commands;
        return bHit;
    }
}
