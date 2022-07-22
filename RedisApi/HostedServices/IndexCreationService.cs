using Redis.OM.Skeleton.Model;

namespace Redis.OM.Skeleton.HostedServices;

public class IndexCreationService : IHostedService
{
    private readonly RedisConnectionProvider _provider;
    public IndexCreationService(RedisConnectionProvider provider)
    {
        _provider = provider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var t1 = _provider.Connection.CreateIndexAsync(typeof(SpellLogic));
        var t2 = _provider.Connection.CreateIndexAsync(typeof(SpellCard));
        var t3 = _provider.Connection.CreateIndexAsync(typeof(Player));
        var t4 = _provider.Connection.CreateIndexAsync(typeof(GameModel));
        await Task.WhenAll(t1, t2, t3, t4);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}