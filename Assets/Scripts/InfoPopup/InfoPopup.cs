using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPopup : MonoBehaviour
{
    private float timer; 
    private TextMeshPro textMesh;
    private Vector3 position;
    private float pos_y;
    private float pos_x;
    private void Awake() 
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        position = transform.position;
        pos_y = position.y;
        pos_x = position.x;
        DestroyObjectDelayed();

    }
    public void Setup(string message, string type) 
    {
        textMesh.text = message;
        if (type == "Red")
        {
            textMesh.color = new Color32(255, 0, 0, 255);
        }
        else if (type=="Golden") 
        {
            textMesh.color = new Color32(255, 213, 0, 255);
        }
        else if (type == "Purple")
        {
            textMesh.color = new Color32(97, 19, 192, 255);
        }
        else if (type == "Green")
        {
            textMesh.color = new Color32(255, 213, 240, 255);
        }
        else if (type == "Blue")
        {
            textMesh.color = new Color32(18, 90, 224, 255);
        }
    }
    void Update() 
    {
        pos_y = pos_y + 0.5f * Time.deltaTime;
        transform.position = new Vector3(pos_x, pos_y, 0);
    }
    void DestroyObjectDelayed()
    {
        // Kills the game object in 2 seconds after loading the object
        Destroy(gameObject, 2f);
    }
}
