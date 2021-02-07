using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;

namespace DiscordHaxx
{
    public class Joiner : RaidBot
    {
#pragma warning disable IDE1006
        private DiscordInvite _invite { get; set; }
#pragma warning restore IDE1006


        public Joiner(JoinRequest request)
        {
            Attack = new Attack(this) { Type = "Joiner", Bots = Server.Bots.Count };

            Threads = request.Threads;
            try
            {
                _invite = new DiscordClient().GetInvite(request.Invite.Split('/').Last());
            }
            catch (DiscordHttpException e)
            {
                if (e.Code == DiscordError.UnknownInvite)
                {
                    Console.WriteLine($"[FATAL] {request.Invite} is invalid");
                    
                    throw new CheckException("Invalid invite");
                }
                else
                {
                    Console.WriteLine($"[ERROR] Unknown: {e.Code} | {e.ErrorMessage}");

                    throw new CheckException($"Code: {e.Code}");
                }
            }
        }


        public override void Start()
        {
            Parallel.ForEach(new List<RaidBotClient>(Server.Bots), new ParallelOptions() { MaxDegreeOfParallelism = Threads }, bot =>
            {
                start:
                if (ShouldStop)
                    return;

                try
                {
                    if (_invite.Type == InviteType.Guild)
                        bot.Client.JoinGuild(_invite.Code);
                    else
                        bot.Client.JoinGroup(_invite.Code);
                }
                catch (DiscordHttpException e)
                {
                    switch (e.Code)
                    {
                        case DiscordError.UnknownInvite:
                            Console.WriteLine($"[ERROR] unknown invite");

                            if (_invite.Type == InviteType.Group)
                                ShouldStop = true;
                            break;
                        case DiscordError.MaximumGuilds:
                            if (bot.Guilds.First().OwnerId == bot.Client.User.Id) bot.Client.DeleteGuild(bot.Guilds.First().Id);
                            else bot.Client.LeaveGuild(bot.Guilds.First().Id);
                            goto start;
                        default:
                            CheckError(e, bot.Client);
                            break;
                    }
                }
                catch (RateLimitException) { }
            });
            Server.OngoingAttacks.Remove(Attack);
        }
    }
}
