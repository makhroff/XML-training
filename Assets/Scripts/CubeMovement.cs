using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Vector3 m_Position;

    public Material m_material;

    CubeData m_CubeData;


    private void Awake()
    {
        LoadData();
    }

    private void Update()
    {
        MoveCube();
        if (Input.GetMouseButtonDown(0))
        {
            SaveCube();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            LoadData();
        }
    }

    void SaveCube()
    {
        SaveSystem.SaveCube(this);
    }
    void LoadData()
    {
        m_CubeData = SaveSystem.LoadData();

        m_material = m_CubeData.material;

        m_Position.x = m_CubeData.position[0];
        m_Position.y = m_CubeData.position[1];
        m_Position.z = m_CubeData.position[2];

        transform.position = m_Position;
    }

    private void MoveCube()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            m_Position.z += 0.005f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_Position.z -= 0.005f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            m_Position.x -= 0.005f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_Position.x += 0.005f;
        }

        transform.position = m_Position;
    }

    private void OnApplicationQuit()
    {
        SaveCube();
    }
}
