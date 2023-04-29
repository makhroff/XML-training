using UnityEngine;

[System.Serializable]
public class CubeData
{
    public float[] position;

    public Material material;

    public CubeData(CubeMovement cube)
    {
        this.material = cube.m_material;

        position = new float[3];

        position[0] = cube.transform.position.x;
        position[1] = cube.transform.position.y;
        position[2] = cube.transform.position.z;
    }
}
