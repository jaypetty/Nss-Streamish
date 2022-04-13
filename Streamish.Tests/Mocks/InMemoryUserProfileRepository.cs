using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streamish.Repositories;
using Streamish.Models;

namespace Streamish.Tests.Mocks
{
    public class InMemoryUserProfileRepository : IUserProfileRepository
    {
        private readonly List<UserProfile> _data;

        public List<UserProfile> InternalData
        {
            get
            {
                return _data;
            }
        }

        public InMemoryUserProfileRepository(List<UserProfile> startingData)
        {
            _data = startingData;
        }

        public void Add(UserProfile profile)
        {
            var lastProfile = _data.Last();
            profile.Id = lastProfile.Id + 1;
            _data.Add(profile);
        }

        public void Delete(int id)
        {
            var profileToDelete = _data.FirstOrDefault(p => p.Id == id);
            if (profileToDelete == null)
            {
                return;
            }

            _data.Remove(profileToDelete);
        }

        public List<UserProfile> GetAll()
        {
            return _data;
        }

        public UserProfile GetById(int id)
        {
            return _data.FirstOrDefault(p => p.Id == id);
        }

        public UserProfile GetByIdWithVideos(int id)
        {
            throw new NotImplementedException();
        }

    }
}
