namespace BrickSchema.Net.Shapes
{
    public class ApparentEnergy : BrickShape
    {
        public List<string> HasUnits
        {
            get
            {

                return new() {
                    "KiloV-A-HR",
                    "MegaV-A-HR",
                    "V-A-HR"
                };
            }

        }
    }


}