using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace StringEditor.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;
    internal Resources()
    {

    }
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (StringEditor.Properties.Resources.resourceMan == null) StringEditor.Properties.Resources.resourceMan = new ResourceManager("StringEditor.Properties.Resources", typeof (StringEditor.Properties.Resources).Assembly);
        return StringEditor.Properties.Resources.resourceMan;
      }
    }
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => StringEditor.Properties.Resources.resourceCulture;
      set => StringEditor.Properties.Resources.resourceCulture = value;
    }
  }
}
