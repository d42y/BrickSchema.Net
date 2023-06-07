namespace BrickSchema.Net.Shapes
{
    public class Conductivity : BrickShape
    {
        public List<string> HasUnits
        {
            get
            {

                return new() {
                    "MegaS-PER-M",
                    "MilliS-PER-M",
                    "MicroS-PER-CentiM",
                    "PicoS-PER-M",
                    "NanoS-PER-CentiM",
                    "S-PER-CentiM",
                    "KiloS-PER-M",
                    "S-PER-M",
                    "DeciS-PER-M",
                    "MicroS-PER-M",
                    "NanoS-PER-M",
                    "MilliS-PER-CentiM"
                };
            }
        }

    }


}