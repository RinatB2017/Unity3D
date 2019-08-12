<<<<<<< HEAD
using System;
using System.Linq;
using UnityEngine;

namespace Packages.Rider.Editor
{
  public static class UnityUtils
  {
    internal static readonly string UnityApplicationVersion = Application.unityVersion;
    
    public static Version UnityVersion
    {
      get
      {
        var ver = UnityApplicationVersion.Split(".".ToCharArray()).Take(2).Aggregate((a, b) => a + "." + b);
        return new Version(ver);
      }
    }
  }
=======
using System;
using System.Linq;
using UnityEngine;

namespace Packages.Rider.Editor
{
  public static class UnityUtils
  {
    internal static readonly string UnityApplicationVersion = Application.unityVersion;
    
    public static Version UnityVersion
    {
      get
      {
        var ver = UnityApplicationVersion.Split(".".ToCharArray()).Take(2).Aggregate((a, b) => a + "." + b);
        return new Version(ver);
      }
    }
  }
>>>>>>> 9b5a8c4fca00507bfc3f7064240cc1922e84bc24
}