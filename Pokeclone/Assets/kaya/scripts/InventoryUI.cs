using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    // Reference to the inventory script
    public INventory inventory;

    // Reference to the UI text element where we will display the inventory
    public TMP_Text inventoryText;
    
    
    void Update()
    {
        // Build the string that will be displayed in the UI
        string text = "Inventory: \n";
        for (int i = 0; i < inventory.currentsize; i++)
        {
            text += " - "+ inventory.item1 + "\n";
            
            Debug.Log("test");
        }

        // Update the text element with the inventory string
        inventoryText.text = text;
    }
}