namespace BrickSchema.Net
{
    public class BrickRelationship : BrickEntity
    {
        public string? ParentId { get; set; } = string.Empty;

        public BrickRelationship() { }

        public BrickRelationship(BrickEntity brickEntity):base(brickEntity)
        {


        }

        public override BrickRelationship Clone()
        {
            var clone = new BrickRelationship(base.Clone());
            clone.ParentId = ParentId;
            return clone;
        }
    }

}