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

        public BrickClass() { 
        
            
        }

        internal BrickClass(BrickEntity entity) : base(entity) { } //for internal cloning

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

        public override BrickClass Clone()
        {
            var clone = new BrickClass(base.Clone());
            return clone;
        }

        
    }

}