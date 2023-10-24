using KitchenData;
using KitchenLib.DevUI;
using UnityEngine;

namespace BlueprintDeskHasWhat
{
    public class MenuList : BaseUI
    {
        public MenuList()
        {
            ButtonName = "BlueprintDesk";
        }
		
        public override void Setup()
        {
            string str = "";
            foreach (Appliance appliance in GetBlueprintDeskAppliances.Appliances)
            {
                str += $"{appliance.Name}\n";
            }
            GUILayout.Label(str);
        }
    }
}