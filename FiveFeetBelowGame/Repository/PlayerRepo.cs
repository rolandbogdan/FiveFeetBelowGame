// <copyright file="PlayerRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Text;
      using System.Threading.Tasks;
      using Model;

      /// <summary>
      /// PlayerRepo class.
      /// </summary>
      public class PlayerRepo : IStorageRepository<PlayerModel>
      {
            /// <summary>
            /// Delete method for delete one PlayerModel entity.
            /// </summary>
            /// <param name="toDelete">PlayerModel type parameter, this is what we want to delete.</param>
            public void Delete(PlayerModel toDelete)
            {
                  throw new NotImplementedException();
            }

            /// <summary>
            /// GetAll method, for list all of the Playermodels.
            /// </summary>
            /// <returns>IQueryable PlayerModel type return.</returns>
            public IQueryable<PlayerModel> GetAll()
            {
                  throw new NotImplementedException();
            }

            /// <summary>
            /// GetOne method, for find one PlayerModel with an id.
            /// </summary>
            /// <param name="id">String type parameter.</param>
            /// <returns>Return one PlayerModel.</returns>
            public PlayerModel GetOne(string id)
            {
                  throw new NotImplementedException();
            }

            /// <summary>
            /// Insert method for insert one new PlayerModel.
            /// </summary>
            /// <param name="toInsert">PlayerModel type parameter.</param>
            public void Insert(PlayerModel toInsert)
            {
                  throw new NotImplementedException();
            }

            /// <summary>
            /// SaveChanges method for the changes.
            /// </summary>
            public void SaveChanges()
            {
                  throw new NotImplementedException();
            }
      }
}
