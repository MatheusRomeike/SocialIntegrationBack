using Application.Interfaces.ServiceInterfaces;
using Data.Contracts;
using Data.Interfaces.RepositoryInterface;
using Domain.Entities.SocialMedia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaService(
            ISocialMediaRepository socialMediaRepository,
            IUnitOfWork unitOfWork)
        {
            _socialMediaRepository = socialMediaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SocialMedia>> SocialMedias()
        {
            return await _socialMediaRepository.GetAllAsync(
                    include: i => i.Include(x => x.SocialMediaConfiguration)
                );
        }
    }
}
