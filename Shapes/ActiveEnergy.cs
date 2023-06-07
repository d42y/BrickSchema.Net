namespace BrickSchema.Net.Shapes
{
    public class ActiveEnergy : BrickShape
    {
        public List<string> HasUnits
        {
            get
            {

                return new() {
                    "W-HR",
                    "MegaW-HR",
                    "KiloW-HR"
                };
            }

        }
    }


}