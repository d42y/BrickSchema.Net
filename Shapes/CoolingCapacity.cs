namespace BrickSchema.Net.Shapes
{
    public class CoolingCapacity : BrickShape
    {
        public List<string> HasUnits
        {
            get
            {

                return new() {
                    "TON_FG",
                    "BTU_IT-PER-HR",
                    "BTU_TH-PER-HR",
                    "W"
                };
            }
        }

    }


}