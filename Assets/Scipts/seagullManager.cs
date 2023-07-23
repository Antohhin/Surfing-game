using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seagullManager : MonoBehaviour
{
    public GameObject seagull;
    public int numberOfseagulls = 10;
    public Vector3 seagullPos;
    GameObject[] listOfseagulls;
    readonly float maxX = 90;
    readonly float maxY = 5f;
    // Start is called before the first frame update
    void Start()
    {
        CreateseagullsOnField();
    }
    private void CreateseagullsOnField()
    {
        listOfseagulls = new GameObject[numberOfseagulls];
        int i = 0;
        while (i < numberOfseagulls)
        {
            float xi = Random.Range(-maxX, maxX);
            float yi = Random.Range(-maxY, maxY);
            List<Collider2D> res = new List<Collider2D>();
            if (Physics2D.OverlapCircle(new Vector2(xi, yi),
                seagull.GetComponent<BoxCollider2D>().size.magnitude * 10,
                new ContactFilter2D(), res) == 0)
            {
                listOfseagulls[i] = Instantiate(seagull,
                    new Vector3(xi, yi, 0), Quaternion.identity);
                i++;
            }
            else
                Debug.Log("seagull cannot be instantiated " + xi + ", " + yi + ", " +
                    seagull.GetComponent<BoxCollider2D>().size.magnitude + ", "
                    + res[0].gameObject.name + ", " + res[0].transform.position);
        }
        seagullPos = listOfseagulls[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
