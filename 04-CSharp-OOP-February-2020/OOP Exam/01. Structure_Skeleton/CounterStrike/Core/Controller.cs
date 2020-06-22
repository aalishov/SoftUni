namespace CounterStrike.Core
{
    using CounterStrike.Core.Contracts;
    using CounterStrike.Models.Guns;
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Models.Maps;
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Repositories;
    using CounterStrike.Utilities.Messages;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            if (type == nameof(Pistol))
            {
                this.guns.Add(new Pistol(name, bulletsCount));
            }
            else if (type == nameof(Rifle))
            {
                this.guns.Add(new Rifle(name, bulletsCount));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (type == nameof(Terrorist))
            {
                players.Add(new Terrorist(username, health, armor, gun));
            }
            else if (type == nameof(CounterTerrorist))
            {
                players.Add(new CounterTerrorist(username, health, armor, gun));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var p in players.Models.OrderBy(x=>x.GetType().Name).ThenByDescending(x=>x.Health).ThenBy(x=>x.Username))
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        //TODO: Check StartGame and PlayerRepository
        public string StartGame()
        {
            return map.Start(this.players.GamePlayers);
        }
    }
}
