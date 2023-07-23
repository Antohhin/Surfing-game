using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject surf;
    public Text energyAmount;
    // Start is called before the first frame update
    void Start()
    {
        energyAmount.text = surf.GetComponent<movesurfer>().energy.ToString().Replace(',', '.');
    }

    // Update is called once per frame
    void Update()
    {
        energyAmount.text = surf.GetComponent<movesurfer>().energy.ToString().Replace(',', '.');
    }
}
