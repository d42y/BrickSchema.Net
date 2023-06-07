namespace BrickSchema.Net.Shapes
{
    public class ComplexPower : BrickShape
    {
        public List<string> HasUnits
        {
            get
            {

                return new() {
                    "MegaV-A",
                    "V-A",
                    "KiloV-A"
                };
            }
        }
    }


}