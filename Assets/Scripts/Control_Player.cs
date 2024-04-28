using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_Player : MonoBehaviour
{
    //ǰ���ٶ�
    public float m_ForwardSpeed = 7.0f;
    //�������
    private Animator m_Anim;
    //��������״̬
    private AnimatorStateInfo m_CurrentBaseState;
    //����״̬����
    bool m_IsEnd = false;
    static int m_jumpState = Animator.StringToHash("Base Layer.jump");
    static int m_slideState = Animator.StringToHash("Base Layer.slide");
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(name);
        //������ǵ�Animator���
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //��ǰ��
        transform.position += Vector3.right * m_ForwardSpeed * Time.deltaTime;
        //get���ڲ��ŵĶ���״̬
        m_CurrentBaseState = m_Anim.GetCurrentAnimatorStateInfo(0);
        if(Input.GetKeyDown(KeyCode.W))
        {
            m_Anim.SetBool("jump", true);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            m_Anim.SetBool("slide", true);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            Change_PlayerZ(true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Change_PlayerZ(false);
        }
        if(m_CurrentBaseState.fullPathHash == m_jumpState)
        {
            m_Anim.SetBool("jump", false);
        }
        else if(m_CurrentBaseState.fullPathHash == m_slideState)
        {
            m_Anim.SetBool("slide", false);
        }
        if (m_IsEnd && Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void Change_PlayerZ(bool IsAD)
    {
        if(IsAD)
        {
            if(transform.position.z == -5f)
            {
                return;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y,
                    transform.position.z + 5f);
            }
        }
        else
        {
            if (transform.position.z == -15f)
            {
                return;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y,
                    transform.position.z - 5f);
            }
        }
    }
    void OnGUI()
    {
        if(m_IsEnd)
        {
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 40;
            style.normal.textColor = Color.red;
            GUI.Label(new Rect(Screen.width/2 - 100,Screen.height/2 -50,200,100),
                "You Lose,Press F1 to Restart",style);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Vehicle_DumpTruck"||other.gameObject.name =="Vehicle_MixerTruck")
        {
            Debug.Log(other.gameObject.name);
            m_IsEnd = true;
            m_ForwardSpeed = 0;
            m_Anim.SetBool("idle", true);
        }
    }
}
