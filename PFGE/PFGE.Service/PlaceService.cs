using PFGE.Core;
using PFGE.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PFGE.Service
{
    public class PlaceService : IPlaceService
    {
        public readonly IRepository<Place> _placeRepository;
        public PlaceService(
            IRepository<Place> placeRepository
            )
        {
            this._placeRepository = placeRepository;
        }

        public bool AddPlace(Place place)
        {
            _placeRepository.Insert(place);
            return true;
        }

        public IList<Place> GetAllPlaces()
        {
           return _placeRepository.GetAll().ToList();
        }
    }
}
