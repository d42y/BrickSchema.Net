namespace BrickSchema.Net.Shapes
{
    public class AmmoniaConcentration : BrickShape
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