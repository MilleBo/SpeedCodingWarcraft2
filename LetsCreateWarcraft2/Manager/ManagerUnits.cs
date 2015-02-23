using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateWarcraft2.Common;
using LetsCreateWarcraft2.Map;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateWarcraft2.Manager
{
    class ManagerUnits
    {
        private List<TeamUnits> _teams;

        public ManagerUnits(ManagerMouse managerMouse, ManagerTiles managerTiles)
        {
            _teams = new List<TeamUnits>();
    
            //For test
            var mapObjects = new List<MapObject>();
            for (int n = 0; n < 4; n++)
            {
                mapObjects.Add(new MapObject(managerMouse, new Sprite(3, 4 + n), managerTiles,this));
            }

            _teams.Add(new TeamUnits(mapObjects,"player",new List<string>()));
        }

        public void LoadContent(ContentManager content)
        {
            _teams.ForEach(t => t.LoadContent(content));
        }

        public void Update()
        {
            _teams.ForEach(t => t.Update());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _teams.ForEach(t => t.Draw(spriteBatch));
        }

        public bool CheckCollision(int x, int y, string id)
        {
            var team = _teams.FirstOrDefault(t => t.GetUnitAtSpace(x, y) != null);
            if (team == null)
                return false; 
            var unit = team.GetUnitAtSpace(x, y);
            if (unit.Id == id)
                return false;

            return true; 
        }
    }
}
