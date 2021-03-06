﻿using SweetScent.Core.Containers;
using System.Threading.Tasks;
using System.Linq;
using System;
using PokemonGo.RocketAPI;
using System.Threading;

namespace SweetScent.Core.Services
{
    public class PogoService : IPogoService
    {
        private Client _client;
        private ISettings _settings;

        public PogoService(ISettings settings)
        {
            _settings = settings;
            _client = new Client(new SettingsMap(_settings));
        }

        public void SetInitialLocation(double lat, double lon, double alt = 0)
        {
            _client.Player.SetCoordinates(lat, lon, alt);
        }

        public async Task<PogoMapResponse> GetMapData(CancellationToken token = default(CancellationToken))
        {
            var mapObjects = await _client.Map.GetMapObjects(token);
            var pokemon = mapObjects.MapCells.SelectMany(m => m.CatchablePokemons);
            var forts = mapObjects.MapCells.SelectMany(m => m.Forts);

            return new PogoMapResponse(forts, pokemon);
        }

        public async Task LoginAsync(string username, string password)
        {
            _client.Settings.PtcUsername = username;
            _client.Settings.PtcPassword = password;
            await _client.Login.DoPtcLogin();
        }
    }
}
