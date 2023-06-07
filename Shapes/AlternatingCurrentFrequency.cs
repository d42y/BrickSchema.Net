namespace BrickSchema.Net.Shapes
{
    public class AlternatingCurrentFrequency : BrickShape
    {

        public List<string> HasUnits
        {
            get
            {

                return new() {
                    "HZ",
                    "GigaHZ",
                    "MegaHZ",
                    "KiloHZ"
                };
            }

        }
    }


}