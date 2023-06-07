namespace BrickSchema.Net.Shapes
{
    public class AbsoluteHumidity : BrickShape
    {

        public List<string> HasUnits
        {
            get
            {

                return new() {
                    "SLUG-PER-FT3",
                    "GRAIN-PER-GAL",
                    "TON_LONG-PER-YD3",
                    "TON_US-PER-YD3",
                    "KiloGM-PER-M3",
                    "OZ_PER-GAL",
                    "TON_SHORT-PER-YD3",
                    "LB-PER-GAL_US",
                    "PlanckDensity",
                    "LB-PER-GAL_UK",
                    "MilliGM-PER-DeciL",
                    "LB-PER-IN3",
                    "LB-PER-FT3",
                    "OZ_PER-IN3",
                    "LB-PER-M3",
                    "LB-PER-YD3",
                    "TON_UK-PER-YD3",
                    "LB-PER-GAL"
                };
            }

        }
    }


}