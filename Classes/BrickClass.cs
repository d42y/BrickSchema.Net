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

        public string Name
        {
            get { return GetProperty<string>(EntityProperties.PropertiesEnum.Name) ?? string.Empty; }

            set { AddOrUpdateProperty(EntityProperties.PropertiesEnum.Name, value); }
        }

        public string Description
        {
            get { return GetProperty<string>(EntityProperties.PropertiesEnum.Description) ?? string.Empty; }

            set { AddOrUpdateProperty(EntityProperties.PropertiesEnum.Description, value); }
        }

        public BrickClass CloneIdentity()
        {
            BrickClass point = new BrickClass();
            point.Id = Id;
            point.Type = Type;
            point.Name = Name;
            point.Description = Description;

            return point;
        }

        
    }

}