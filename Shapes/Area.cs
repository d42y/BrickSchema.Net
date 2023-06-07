namespace BrickSchema.Net.Shapes
{
    public class Area : BrickShape
    {
        public List<string> HasUnits
        {
            get
            {

                return new() {
                    "FT2",
                    "M2"
                };
            }

        }
    }


}