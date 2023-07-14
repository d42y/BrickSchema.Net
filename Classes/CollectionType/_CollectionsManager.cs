using BrickSchema.Net.Classes.Collection.Loop;
using BrickSchema.Net.Classes.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public partial class BrickSchemaManager
    {
        //Collection
        public Loop AddCollectionLoop(string? id = null) => AddEntity<Loop>(id);
        public Air AddCollectionLoopAir(string? id = null) => AddEntity<Air>(id);
        public Water AddCollectionLoopWater(string? id = null) => AddEntity<Water>(id);
        public ChilledWater AddCollectionLoopChilledWater(string? id = null) => AddEntity<ChilledWater>(id);
        public DomesticWater AddCollectionLoopDomesticWater(string? id = null) => AddEntity<DomesticWater>(id);
        public HotWater AddCollectionLoopHotWater(string? id = null) => AddEntity<HotWater>(id);
        public HeatingWater AddCollectionLoopHeatingWater(string? id = null) => AddEntity<HeatingWater>(id);

        public PVArray AddCollectionPVArray(string? id = null) => AddEntity<PVArray>(id);
        public PhotovoltaicArray AddCollectionPhotovoltaicArray(string? id = null) => AddEntity<PhotovoltaicArray>(id);
        public Portfolio AddCollectionPortfolio(string? id = null) => AddEntity<Portfolio>(id);
        public BrickSchema.Net.Classes.Collection.System AddCollectionSystem(string? id = null) => AddEntity<BrickSchema.Net.Classes.Collection.System>(id);
    }
}
