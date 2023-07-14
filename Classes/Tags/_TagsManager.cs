using BrickSchema.Net.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickSchema.Net
{
    public partial class BrickSchemaManager
    {
        //Tag
        public Tag AddTag(string name)
        {
            Tag? tag = null;
            tag = GetTag(name);
            if (tag == null)
            {
                tag = AddEntity<Tag>();
                tag.Name = name;
            }
            return tag;
        }
    }
}
