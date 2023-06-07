namespace BrickSchema.Net.Shapes
{
    public class COConcentration : BrickShape
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