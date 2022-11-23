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
        [PropertyType(PropertyType.Header, name: "ContentType")]
        public string ContentType { get; } = "application/x-www-form-urlencoded";


        [PropertyType(PropertyType.Header)]
        public string Token { get => Globals.Token; }
    }
}
