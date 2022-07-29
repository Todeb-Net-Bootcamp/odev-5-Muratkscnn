using Business.Abstract;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonelManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task Add(Personel t)
        {
            await _unitOfWork.Personels.Create(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(Personel t)
        {
            await _unitOfWork.Personels.Delete(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Personel> GetById(int id)
        {

            return await _unitOfWork.Personels.GetById(id);
        }

        public async Task<List<Personel>> GetList()
        {
            return await _unitOfWork.Personels.GetAll();

        }

        public async Task Update(Personel t)
        {

            await _unitOfWork.Personels.Update(t);
            await _unitOfWork.SaveAsync();
        }
    }
}
