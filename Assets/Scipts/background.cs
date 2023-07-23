using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class background : MonoBehaviour
{
    // Surfer and his mate
    public GameObject surf;
    public GameObject mateSurfer;

    //Pizza Manager
    public GameObject pizza;
    public int numberOfpizzas = 10;
    Vector3 pizzaPos;
    GameObject[] listOfpizzas;
    readonly float minX = 10;
    readonly float maxX = 95;
    readonly float maxY = 5f;

    //Buoy Manager
    public GameObject buoy;
    public int numberOfbuoys = 10;
    Vector3 buoyPos;
    GameObject[] listOfbuoys;


    //Seagull Manager
    public GameObject seagull;
    public int numberOfseagulls = 10;
    Vector3 seagullPos;
    GameObject[] listOfseagulls;


    //Boat Manager
    public GameObject boat;
    public int numberOfboats = 10;
    Vector3 boatPos;
    GameObject[] listOfboats;
    
 

    // Start is called before the first frame update
    void Start()
    {
        CreatepizzasOnField();
        CreatebuoysOnField();
        CreateseagullsOnField();
        CreateboatsOnField();
        Instantiate(mateSurfer, new Vector3(98, 4, 0), Quaternion.identity);
        pizzaTriggerd();
        buoyTriggerd();
        seagullTriggerd();
        boatTriggerd();
    }
    //pizza manager
    private void CreatepizzasOnField()
    {
        listOfpizzas = new GameObject[numberOfpizzas];
        int i = 0; int steps = 0;
        while (i < numberOfpizzas)
        {
            float xi = Random.Range(minX, maxX);
            float yi = Random.Range(-maxY, maxY);
            List<Collider2D> res = new List<Collider2D>();
            if (Physics2D.OverlapCircle(new Vector2(xi, yi),
                pizza.GetComponent<CircleCollider2D>().radius * 2,
                new ContactFilter2D(), res) == 0)
            {
                listOfpizzas[i] = Instantiate(pizza,
                    new Vector3(xi, yi, 0), Quaternion.identity);
                i++;
            }
            else
                Debug.Log("pizza cannot be instantiated " + xi + ", " + yi + ", " +
                    pizza.GetComponent<CircleCollider2D>().radius + ", "
                    + res[0].gameObject.name + ", " + res[0].transform.position);
            steps++;
            //if (steps > 20) break;
        }
        //pizzaPos = listOfpizzas[0].transform.position;
    }
    //buoy manager
    private void CreatebuoysOnField()
    {
        listOfbuoys = new GameObject[numberOfbuoys];
        int i = 0; int steps = 0;
        while (i < numberOfbuoys)
        {
            float xi = Random.Range(minX, maxX);
            float yi = Random.Range(-maxY, maxY);
            List<Collider2D> res = new List<Collider2D>();
            if (Physics2D.OverlapCircle(new Vector2(xi, yi),
                buoy.GetComponent<CapsuleCollider2D>().size.magnitude * 2,
                new ContactFilter2D(), res) == 0)
            {
                listOfbuoys[i] = Instantiate(buoy,
                    new Vector3(xi, yi, 0), Quaternion.identity);
                i++;
            }
            else
                Debug.Log("buoy cannot be instantiated " + xi + ", " + yi + ", " +
                    buoy.GetComponent<CapsuleCollider2D>().size.magnitude + ", "
                    + res[0].gameObject.name + ", " + res[0].transform.position);
            steps++;
            //if (steps > 20) break;
        }
        //buoyPos = listOfbuoys[0].transform.position;
    }

    //seagull manager
    private void CreateseagullsOnField()
    {
        listOfseagulls = new GameObject[numberOfseagulls];
        int i = 0; int steps = 0;
        while (i < numberOfseagulls)
        {
            float xi = Random.Range(minX, maxX);
            float yi = Random.Range(-maxY, maxY);
            List<Collider2D> res = new List<Collider2D>();
            if (Physics2D.OverlapCircle(new Vector2(xi, yi),
                seagull.GetComponent<CircleCollider2D>().radius * 2,
                new ContactFilter2D(), res) == 0)
            {
                listOfseagulls[i] = Instantiate(seagull,
                    new Vector3(xi, yi, 0), Quaternion.identity);
                i++;
            }
            else
                Debug.Log("seagull cannot be instantiated " + xi + ", " + yi + ", " +
                    seagull.GetComponent<CircleCollider2D>().radius + ", "
                    + res[0].gameObject.name + ", " + res[0].transform.position);
            steps++;
            //if (steps > 20) break;
        }
        //seagullPos = listOfseagulls[0].transform.position;
    }

    //boat manager
    private void CreateboatsOnField()
    {
        listOfboats = new GameObject[numberOfboats];
        int i = 0; int steps = 0;
        while (i < numberOfboats)
        {
            float xi = Random.Range(minX, maxX);
            float yi = Random.Range(-maxY, maxY);
            List<Collider2D> res = new List<Collider2D>();
            if (Physics2D.OverlapCircle(new Vector2(xi, yi),
                boat.GetComponent<PolygonCollider2D>().points.Max(vector => vector.x) -
                boat.GetComponent<PolygonCollider2D>().points.Min(vector => vector.x),
                new ContactFilter2D(), res) == 0) 
            {
                listOfboats[i] = Instantiate(boat,
                    new Vector3(xi, yi, 0), Quaternion.identity);
                i++;
            }

            steps++;
           //if (steps > 20) break;
        }
        //boatPos = listOfboats[0].transform.position;
    }
    private void pizzaTriggerd()
    {
        for (int i = 0; i < listOfpizzas.Length; i++) { listOfpizzas[i].GetComponent<CircleCollider2D>().isTrigger = true; }
    }
    private void buoyTriggerd() {
        for (int i = 0; i < listOfbuoys.Length; i++) { listOfbuoys[i].GetComponent<CapsuleCollider2D>().isTrigger = true; }
    }
    private void seagullTriggerd() {
        for (int i = 0; i < listOfseagulls.Length; i++) { listOfseagulls[i].GetComponent<CircleCollider2D>().isTrigger = true; }
    }
    private void boatTriggerd() {
        for (int i = 0; i < listOfboats.Length; i++) { listOfboats[i].GetComponent<PolygonCollider2D>().isTrigger = true; }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(surf.transform.position.x, transform.position.y, transform.position.z);
    }
}
