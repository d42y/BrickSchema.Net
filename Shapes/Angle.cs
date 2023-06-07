namespace BrickSchema.Net.Shapes
{
    public class Angle : BrickShape
    {
        public List<string> HasUnits
        {
            get
            {

                return new() {
                    "MicroRAD",
                    "MilliARCSEC",
                    "RAD",
                    "GON",
                    "MilliRAD",
                    "MIN_Angle",
                    "REV",
                    "MIL",
                    "GRAD",
                    "ARCMIN",
                    "ARCSEC",
                    "DEG"
                };
            }

        }
    }


}