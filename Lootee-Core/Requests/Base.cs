using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiCore.Attributes;
using ApiCore.Models;

namespace Lootee_Core.Requests
{
    internal class Base : RequestDefinition
    {
        [PropertyType(PropertyType.Header)]
        public string ContentType { get; set; }
    }
}
