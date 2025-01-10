using CommandService.Models;

namespace CommandService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();
        //Platform
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform plat);
        bool PlatformExists(int platformId);
        bool ExternalPlatformExists(int externalPlatformId);
        //Command
        IEnumerable<Command> GetCommandsForPlatform(int PlatformId);
        Command GetCommand(int PlatformId, int CommandId);
        void CreateCommand(int PlatformId, Command command);

    }
}