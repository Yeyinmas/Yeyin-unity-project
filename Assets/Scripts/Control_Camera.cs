using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Camera : MonoBehaviour
{
    public float m_DistanceAway = 5f;
    public float m_DistanceHeight = 10f;
    public float smooth = 2f;
    private Vector3 m_TargetPosition;
    Transform m_Follow;
    // Start is called before the first frame update
    void Start()
    {
        m_Follow = GameObject.Find("Player").transform;
        transform.rotation = Quaternion.Euler(new Vector3(28, 90, 0));
    }

    // Update is called once per frame
    void Update()
    {
        m_TargetPosition = m_Follow.position + Vector3.up * m_DistanceHeight - 
            m_Follow.forward * m_DistanceAway;
        transform.position = Vector3.Lerp(transform.position, m_TargetPosition, Time.deltaTime * smooth);
    }
}
