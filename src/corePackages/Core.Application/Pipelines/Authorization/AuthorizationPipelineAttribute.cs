using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Authorization;


[AttributeUsage(AttributeTargets.Class)]
public class AuthorizationPipelineAttribute : Attribute
{
    /// <summary>
    /// Define rules seperating with commas
    /// </summary>
    public string Roles { get; set; }
}

