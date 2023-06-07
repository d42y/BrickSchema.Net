namespace BrickSchema.Net.Shapes
{
    public class CurrentFlowType : BrickShape
    {
        public List<string> HasUnits
        {
            get
            {

                return new() {
                    "AC",
                    "DC"
                };
            }
        }
    }


}