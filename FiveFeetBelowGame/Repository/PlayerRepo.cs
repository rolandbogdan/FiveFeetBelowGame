// <copyright file="PlayerRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
      using Model;
      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Text;
      using System.Threading.Tasks;

      public class PlayerRepo : IStorageRepository<PlayerModel>
      {
            public void Delete(PlayerModel toDelete)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<PlayerModel> GetAll()
            {
                  throw new NotImplementedException();
            }

            public PlayerModel GetOne(string id)
            {
                  throw new NotImplementedException();
            }

            public void Insert(PlayerModel toInsert)
            {
                  throw new NotImplementedException();
            }

            public void SaveChanges()
            {
                  throw new NotImplementedException();
            }
      }
}
