using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sharp.Extensions.EntityHookManager;
using Sharp.Extensions.GameEventManager;
using Sharp.Extensions.CommandManager;
using Sharp.Shared;
using Sharp.Shared.Abstractions;

namespace ModuleName;

public class ModuleName : IModSharpModule
{
    private readonly InterfaceBridge    _bridge;
    private readonly ILogger<ModuleName> _logger;
    private readonly IServiceProvider   _serviceProvider;
    
    public ModuleName(
        ISharedSystem sharedSystem,
        string dllPath,
        string sharpPath,
        Version version,
        IConfiguration coreConfiguration,
        bool hotReload)
    {
        var bridge = new InterfaceBridge(dllPath, sharpPath, version, sharedSystem);

        var configuration = new ConfigurationBuilder()
                            .AddJsonFile(Path.Combine(dllPath, "appsettings.json"), false, false)
                            .Build();

        // Uncomment if you want to use GameData stuff.
        // sharedSystem.GetModSharp().GetGameData().Register("ModuleName.games");

        var services = new ServiceCollection();

        services.AddSingleton(bridge);
        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton(sharedSystem.GetLoggerFactory());
        services.AddLogging(p => { p.ClearProviders(); });

        services.AddSingleton(sharedSystem);
        services.AddSingleton(sharedSystem.GetModSharp().GetGameData());
        services.AddEntityHookManager();
        services.AddGameEventManager();
        services.AddCommandManager();

        _bridge          = bridge;
        _logger          = sharedSystem.GetLoggerFactory().CreateLogger<ModuleName>();
        _serviceProvider = services.BuildServiceProvider();
    }

    public bool Init()
    {
        _serviceProvider.LoadAllSharpExtensions();

        return true;
    }

    public void Shutdown()
    {
        _serviceProvider.ShutdownAllSharpExtensions();

        // Uncomment if you want to use GameData stuff.
        // _bridge.GetModSharp().GetGameData().Unregister("ModuleName.games");
    }

    string IModSharpModule.DisplayName => "ProjectDisplayName";
    string IModSharpModule.DisplayAuthor => "ProjectDisplayAuthor";
}
