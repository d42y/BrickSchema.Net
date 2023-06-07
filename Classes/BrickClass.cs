using System.Runtime.CompilerServices;

namespace BrickSchema.Net.Classes
{
    public class BrickClass : BrickEntity {

        //events
        public event EventHandler OnValueChanged;
        
        internal void NotifyValueChange()
        {
            OnValueChanged?.Invoke(this, EventArgs.Empty);
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public BrickClass CloneIdentity()
        {
            Point point = new Point();
            point.Id = Id;
            point.Type = Type;
            point.Name = Name;
            point.Description = Description;

            return point;
        }

        
    }

}