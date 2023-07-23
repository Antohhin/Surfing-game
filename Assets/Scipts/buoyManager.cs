using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buoyManager : MonoBehaviour
{
    public GameObject buoy;
    public int numberOfbuoys = 10;
    public Vector3 buoyPos;
    GameObject[] listOfbuoys;
    readonly float maxX = 90;
    readonly float maxY = 5f;
    // Start is called before the first frame update
    void Start()
    {
        CreatebuoysOnField();
    }
    private void CreatebuoysOnField()
    {
        listOfbuoys = new GameObject[numberOfbuoys];
        int i = 0;
        while (i < numberOfbuoys)
        {
            float xi = Random.Range(-maxX, maxX);
            float yi = Random.Range(-maxY, maxY);
            List<Collider2D> res = new List<Collider2D>();
            if (Physics2D.OverlapCircle(new Vector2(xi, yi),
                buoy.GetComponent<BoxCollider2D>().size.magnitude * 10,
                new ContactFilter2D(), res) == 0)
            {
                listOfbuoys[i] = Instantiate(buoy,
                    new Vector3(xi, yi, 0), Quaternion.identity);
                i++;
            }
            else
                Debug.Log("buoy cannot be instantiated " + xi + ", " + yi + ", " +
                    buoy.GetComponent<BoxCollider2D>().size.magnitude + ", "
                    + res[0].gameObject.name + ", " + res[0].transform.position);
        }
        buoyPos = listOfbuoys[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
