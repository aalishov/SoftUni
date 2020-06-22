namespace CounterStrike.Models.Maps
{
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class Map : IMap
    {
        private List<Terrorist> terrorists = new List<Terrorist>();
        private List<CounterTerrorist> counterTerrorists = new List<CounterTerrorist>();
        public string Start(ICollection<IPlayer> players)
        {
            SeparatesPlayers(players);

            while (terrorists.Any(x => x.IsAlive == true) && counterTerrorists.Any(x => x.IsAlive == true))
            {
                foreach (var terrorist in terrorists)
                {
                    foreach (var cTerrorist in counterTerrorists)
                    {
                        if (cTerrorist.IsAlive)
                        {
                            int damage = terrorist.Gun.Fire();
                            cTerrorist.TakeDamage(damage); 
                        }                        
                    }
                }

                foreach (var cTerroist in counterTerrorists)
                {
                    foreach (var terrorist in terrorists)
                    {
                        if (terrorist.IsAlive)
                        {
                            int damage = cTerroist.Gun.Fire();
                            terrorist.TakeDamage(damage);
                        }                        
                    }
                }
            }

            if (terrorists.Any(x=>x.IsAlive))
            {
                return "Terrorist wins!";
            }
            else 
            {
                return "Counter Terrorist wins!";
            }
           
        }

        private void SeparatesPlayers(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player.GetType().Name == nameof(Terrorist))
                {
                    terrorists.Add((Terrorist)player);
                }
                else if (player.GetType().Name == nameof(CounterTerrorist))
                {
                    counterTerrorists.Add((CounterTerrorist)player);
                }
            }
        }
    }
}
