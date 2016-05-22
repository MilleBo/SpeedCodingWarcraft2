using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateWarcraft2.Map;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OpenTK.Audio.OpenAL;

namespace LetsCreateWarcraft2.Common
{
    class TeamUnits
    {
        private List<MapObject> _units;
        public string TeamName { get; private set; }
        public List<string> Allies { get; private set; } 

        public TeamUnits(List<MapObject> units, string teamName, List<string> allies)
        {
            _units = units;
            TeamName = teamName;
            Allies = allies; 
        }

        public MapObject GetUnitAtSpace(int x, int y)
        {
            return _units.FirstOrDefault(u => u.AtSpace().X == x && u.AtSpace().Y == y); 
        }

        public void LoadContent(ContentManager content)
        {
            _units.ForEach(u => u.LoadContent(content));
        }

        public void Update()
        {
            _units.ForEach(u => u.Update());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _units.ForEach(u => u.Draw(spriteBatch));
        }


    }
}
