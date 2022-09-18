using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Authorization;


[AttributeUsage(AttributeTargets.Class)]
public class AuthorizeAttribute : Attribute
{
    public string[] Roles { get; set; }
}

