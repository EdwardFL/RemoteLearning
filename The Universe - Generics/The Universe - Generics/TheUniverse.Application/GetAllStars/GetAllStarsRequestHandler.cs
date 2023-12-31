﻿using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;
using System.Collections.Generic;

namespace iQuest.TheUniverse.Application.GetAllStars
{
    public class GetAllStarsRequestHandler : IRequestHandler<GetAllStarsRequest, List<StarInfo>>
    {
        public List<StarInfo> Execute(GetAllStarsRequest request)
        {
            List<StarInfo> starsInfo = new List<StarInfo>();

            IEnumerable<Galaxy> galaxies = Universe.Instance.EnumerateGalaxies();

            foreach (Galaxy galaxy in galaxies)
            {
                IEnumerable<string> stars = galaxy.EnumerateStars();

                foreach (string star in stars)
                {
                    StarInfo starInfo = new StarInfo
                    {
                        GalaxyName = galaxy.Name,
                        StarName = star
                    };

                    starsInfo.Add(starInfo);
                }
            }

            return starsInfo;
        }
    }
}