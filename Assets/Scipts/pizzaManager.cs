using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizzaManager : MonoBehaviour
{
    public GameObject pizza;
    public int numberOfpizzas = 10;
    public Vector3 pizzaPos;
    GameObject[] listOfpizzas;
    readonly float maxX = 95;
    readonly float maxY = 5f;
    // Start is called before the first frame update
    void Start()
    {
        CreatepizzasOnField();
    }
    private void CreatepizzasOnField()
    {
        listOfpizzas = new GameObject[numberOfpizzas];
        int i = 0;
        while (i < numberOfpizzas)
        {
            float xi = Random.Range(-maxX, maxX);
            float yi = Random.Range(-maxY, maxY);
            List<Collider2D> res = new List<Collider2D>();
            if (Physics2D.OverlapCircle(new Vector2(xi, yi),
                pizza.GetComponent<BoxCollider2D>().size.magnitude * 10,
                new ContactFilter2D(), res) == 0)
            {
                listOfpizzas[i] = Instantiate(pizza,
                    new Vector3(xi, yi, 0), Quaternion.identity);
                i++;
            }
            else
                Debug.Log("pizza cannot be instantiated " + xi + ", " + yi + ", " +
                    pizza.GetComponent<BoxCollider2D>().size.magnitude + ", "
                    + res[0].gameObject.name + ", " + res[0].transform.position);
        }
        pizzaPos = listOfpizzas[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
