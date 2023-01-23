using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    // Reference to the inventory script
    public INventory inventory;
    public Canvas CanvasObject;   
    // Reference to the UI text element where we will display the inventory
    public TMP_Text inventoryText;
    //public Image uiitemimg;
    //public Image uiitemimg2;

    void Start()
    {
        inventory = GameObject.Find("character").GetComponent<INventory>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown("i")&& CanvasObject.GetComponent<Canvas>().enabled == true)
        {
            CanvasObject.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown("i") && CanvasObject.GetComponent<Canvas>().enabled == false)
        {
            CanvasObject.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
    }

    public void Pickup()
    {
        // Build the string that will be displayed in the UI
        string text = "Inventory:\n";
        for (int i = 0; i < inventory.currentsize; i++)
        {
            char[] whitespace = new char[] { ' ', '\t' };

            text += " - " + inventory.item1.name + "\n";
        }

        // Update the text element with the inventory string
        inventoryText.text = text;
    }
}