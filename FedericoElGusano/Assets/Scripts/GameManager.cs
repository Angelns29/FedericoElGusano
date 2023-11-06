using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float velocidad = 2f;
    private float positionVerticalPlataforma2 = -5.2f;
    private float positionVerticalPlataforma = -4.5f;
    private float posicionHorizontalPlataforma2 = 15f;
    private float posicionHorizontalPlataforma = 16f;
    public GameObject col;
    public GameObject col2;
    public List<GameObject> cols;
    public List<GameObject> cols2;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 32; i++)
        {
            cols.Add(Instantiate(col, new Vector2(-16 + i, positionVerticalPlataforma), Quaternion.identity));
            cols2.Add(Instantiate(col2, new Vector2(-15 + i, positionVerticalPlataforma2), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < cols.Count;i++)
        {
            if (cols[i].transform.position.x <= -16)
            {
                cols[i].transform.position = new Vector3(posicionHorizontalPlataforma, positionVerticalPlataforma, 0);
            }

            cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;

            if (cols2[i].transform.position.x <= -15)
            {
                cols2[i].transform.position = new Vector3(posicionHorizontalPlataforma2, positionVerticalPlataforma2, 0);
            }
            cols2[i].transform.position = cols2[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }
    }
}
