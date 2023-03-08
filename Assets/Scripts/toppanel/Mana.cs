using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public int minimum;
    public int maximum;
    public int current;
    public Image mask;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        float currentOfSet = current - minimum;
        float maxiumOfSet = maximum - minimum;
        float fillAmmount = currentOfSet / maxiumOfSet;
        mask.fillAmount = fillAmmount;
    }
}
