using PFGE.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFGE.Service
{
    public interface IPlaceService
    {
        bool AddPlace(Place place);        

        IList<Place> GetAllPlaces();
    }
}
