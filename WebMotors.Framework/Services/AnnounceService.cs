﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Framework.Entities;
using WebMotors.Framework.Exceptions;
using WebMotors.Framework.Repositories;
using WebMotors.Framework.ThirdAPIs;

namespace WebMotors.Framework.Services
{
    public class AnnounceService : IAnnounceService
    {

        #region Properties
        public WebMotorsAPI _webMotorsAPI;
        public WebMotorsAPI WebMotorsAPI { get { return _webMotorsAPI; } }


        public IAnnounceRepository _announceRepository;
        public IAnnounceRepository AnnounceRepository { get { return _announceRepository; } }

        #endregion

        #region Ctor

        public AnnounceService(WebMotorsAPI webMotorsAPI , IAnnounceRepository announceRepository)
        {
            _webMotorsAPI = webMotorsAPI;
            _announceRepository = announceRepository;
        }

        #endregion

        #region Methods
        public async Task<int> DeleteAnnounce(Guid uniqueId)
        {
            if (uniqueId == Guid.Empty)
                throw new BadRequestException("The uniqueId of Announce is required.");

            return await AnnounceRepository.RemoveAnnounceAsync(uniqueId);
        }

        public async Task<Announce> GetAnnounceByUniqueId(Guid uniqueId)
        {
            if (uniqueId == Guid.Empty)
                throw new BadRequestException("The uniqueId of Announce is required.");

            var entity = await AnnounceRepository.GetAnnounceAsync(uniqueId);

            if (entity == null)
                throw new NotFoundException("");

            return entity;
        }

        public async Task<Announce> PostAnnounce(Announce entity)
        {
            if (entity == null)
                throw new BadRequestException("");

            return await AnnounceRepository.InsertAnnounceAsync(entity);
        }

        public async Task<int> PutAnnounce(Guid uniqueId)
        {
            if (uniqueId == Guid.Empty)
                throw new BadRequestException("The uniqueId of Announce is required.");

            var entity = await AnnounceRepository.GetAnnounceAsync(uniqueId);

            if (entity == null)
                throw new NotFoundException("");

            return await AnnounceRepository.UpdateAnnounceAsync(entity);
        }

        public async Task<IList<Announce>> ListAnnounce()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
