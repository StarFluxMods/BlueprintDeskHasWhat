using System.Collections.Generic;
using Kitchen;
using Kitchen.ShopBuilder;
using KitchenData;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;

namespace BlueprintDeskHasWhat
{
    public class GetBlueprintDeskAppliances : GameSystemBase, IModSystem
    {
        private EntityQuery _query;
        public static List<Appliance> Appliances = new List<Appliance>();
        protected override void Initialise()
        {
            _query = GetEntityQuery(typeof(CShopBuilderOption));
        }

        protected override void OnUpdate()
        {
            NativeArray<CShopBuilderOption> shopBuilderOptions = _query.ToComponentDataArray<CShopBuilderOption>(Allocator.TempJob);
            Appliances.Clear();
            foreach (CShopBuilderOption option in shopBuilderOptions)
            {
                if (option.IsSuitableForDesk())
                {
                    if (GameData.Main.TryGet(option.Appliance, out Appliance appliance))
                        Appliances.Add(appliance);
                }
            }

            shopBuilderOptions.Dispose();
        }
    }
}