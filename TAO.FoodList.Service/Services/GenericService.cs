using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Repositories;
using TAO.FoodList.Core.Services;
using TAO.FoodList.Core.UnitOfWork;
using TAO.FoodList.Service.AutoMapper;
using TAO.FoodList.Shared.Dtos;

namespace TAO.FoodList.Service.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _repository;
        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<Response<TDto>> AddAsync(TDto dto)
        {
            var newEntiy = ObjectMapper.Mapper.Map<TEntity>(dto);
            await _repository.AddAsync(newEntiy);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntiy);
            return Response<TDto>.Success(newDto, 200);
        }
        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = ObjectMapper.Mapper.Map<List<TDto>>(await _repository.GetAll().ToListAsync());
            return Response<IEnumerable<TDto>>.Success(entities, 200);
        }
        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return Response<TDto>.Fail(404, "Id not found.", false);

            }
            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(entity), 204);
        }
        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var isExistsEntity = await _repository.GetByIdAsync(id);
            if (isExistsEntity == null)
            {
                return Response<NoDataDto>.Fail(404, "Id not found.", false);
            }
            _repository.Remove(isExistsEntity);

            _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(204);

        }
        public async Task<Response<NoDataDto>> Update(TDto dto, int id)
        {
            var isExistEntity = await _repository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail(404, "Id not found.", false);
            }
            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(dto);
            _repository.Update(updateEntity);
            _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> expression)
        {
            var list = _repository.Where(expression);
            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()), 200);

        }
    }
}
