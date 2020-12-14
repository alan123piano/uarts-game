using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaxButton : MonoBehaviour
{
    public void GiveSolarPanel()
    {
        PlayerVariables.addToInventory(new Item("Solar Panel", true));
    }

    public void GiveVBucks()
    {
        PlayerVariables.addToInventory(new Item("real v-bucks", false));
    }
}
