using Sharp.Shared;
using Microsoft.Extensions.Configuration;

namespace ModuleName;

public class ModuleName : IModSharpModule
{
    public ModuleName(
        ISharedSystem sharedSystem,
        string dllPath,
        string sharpPath,
        Version version,
        IConfiguration configuration,
        bool hotReload)
    {

    }

    public bool Init()
    {
        return true;
    }

    public void Shutdown()
    {
    }

    string IModSharpModule.DisplayName => "ProjectDisplayName";
    string IModSharpModule.DisplayAuthor => "ProjectDisplayAuthor";
}
