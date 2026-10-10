using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

namespace BotState;

// Utilities.GetPlayers() only scans slots < Server.MaxPlayers, which is 1 on a listen
// server started with `map` from the console, so it misses every bot there.
internal static class ControllerScan
{
    public static List<CCSPlayerController> Players() =>
        Utilities.FindAllEntitiesByDesignerName<CCSPlayerController>("cs_player_controller")
            .Where(p => p.IsValid && !p.IsHLTV && p.Connected == PlayerConnectedState.Connected)
            .ToList();
}
