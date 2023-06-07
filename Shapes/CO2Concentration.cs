namespace BrickSchema.Net.Shapes
{
    public class CO2Concentration : BrickShape
    {
        public List<string> HasUnits
        {
            get
            {

                return new() {
                    "PPM",
                    "PPB"
                };
            }

        }

    }


}