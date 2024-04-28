using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    bool m_ISFirst;
    public GameObject[] m_RoadArray;
    public Transform[] m_ObstaclePosArray;
    public GameObject[] m_ObstacleArray;
    public void Change_Road(int index)
    { 
        if(m_ISFirst && index==0)
        {
            m_ISFirst = false;
            return;
        }
        else
        {
            int lastIndex = index - 1;
            if (lastIndex < 0) lastIndex = 2;
            m_RoadArray[lastIndex].transform.position = m_RoadArray[lastIndex].
                transform.position + new Vector3(150, 0, 0);
            m_ObstaclePosArray[lastIndex].transform.position = m_ObstaclePosArray[lastIndex].
                transform.position + new Vector3(150, 0, 0);
        }
    }

    public void Spawn_Obstacle(int index )
    {
        GameObject[] obsPast = GameObject.FindGameObjectsWithTag("Obstacle" + index);
        for(int i=0; i<obsPast.Length;i++)
        {
            Destroy(obsPast[i]);
        }
        foreach(Transform item in m_ObstaclePosArray[index])
        {
            GameObject prefab = m_ObstacleArray[Random.Range(0, m_ObstacleArray.Length)];
            Vector3 eulerAngle = new Vector3(0, Random.Range(0, 360), 0);
            GameObject obj = Instantiate(prefab, item.position, Quaternion.Euler(eulerAngle));
            obj.tag = "Obstacle" + index;
        }
    }
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
