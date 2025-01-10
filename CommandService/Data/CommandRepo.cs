using CommandService.Models;

namespace CommandService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _dbContext;
        public CommandRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() >= 0;
        }
        //Platform
        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _dbContext.Platforms.ToList();
        }
        public void CreatePlatform(Platform plat)
        {
            if (plat == null)
                throw new ArgumentNullException(nameof(plat));
            _dbContext.Platforms.Add(plat);
        }
        public bool PlatformExists(int platformId)
        {
            return _dbContext.Platforms.Any(p => p.Id == platformId);
        }

        public bool ExternalPlatformExists(int externalPlatformId)
        {
            return _dbContext.Platforms.Any(p => p.ExternalID == externalPlatformId);
        }
        //Command
        public IEnumerable<Command> GetCommandsForPlatform(int PlatformId)
        {
            return _dbContext.Commands.Where(c => c.PlatformId == PlatformId);
        }
        public Command GetCommand(int PlatformId, int CommandId)
        {
            return _dbContext.Commands.Where(c => c.PlatformId == PlatformId && c.Id == CommandId).FirstOrDefault();
        }
        public void CreateCommand(int PlatformId, Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            command.PlatformId = PlatformId;
            _dbContext.Commands.Add(command);
        }
    }
}