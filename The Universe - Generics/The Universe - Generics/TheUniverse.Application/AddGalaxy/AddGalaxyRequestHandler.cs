using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;
using System;

namespace iQuest.TheUniverse.Application.AddGalaxy
{
    public class AddGalaxyRequestHandler : IRequestHandler<AddGalaxyRequest, bool>
    {
        public bool Execute(AddGalaxyRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            string galaxyName = request.GalaxyDetailsProvider.GetGalaxyName();
            return Universe.Instance.AddGalaxy(galaxyName);
        }
    }
}