using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatManager : MonoBehaviour
{
    public GameObject boat;
    public int numberOfboats = 10;
    public Vector3 boatPos;
    GameObject[] listOfboats;
    readonly float maxX = 90;
    readonly float maxY = 5f;
    // Start is called before the first frame update
    void Start()
    {
        CreateboatsOnField();
    }
    private void CreateboatsOnField()
    {
        listOfboats = new GameObject[numberOfboats];
        int i = 0;
        while (i < numberOfboats)
        {
            float xi = Random.Range(-maxX, maxX);
            float yi = Random.Range(-maxY, maxY);
            List<Collider2D> res = new List<Collider2D>();
            if (Physics2D.OverlapCircle(new Vector2(xi, yi),
                boat.GetComponent<BoxCollider2D>().size.magnitude * 10,
                new ContactFilter2D(), res) == 0)
            {
                listOfboats[i] = Instantiate(boat,
                    new Vector3(xi, yi, 0), Quaternion.identity);
                i++;
            }
            else
                Debug.Log("boat cannot be instantiated " + xi + ", " + yi + ", " +
                    boat.GetComponent<BoxCollider2D>().size.magnitude + ", "
                    + res[0].gameObject.name + ", " + res[0].transform.position);
        }
        boatPos = listOfboats[0].transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
