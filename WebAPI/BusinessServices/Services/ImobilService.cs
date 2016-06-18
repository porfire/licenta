using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
    public class ImobilService : IImobilSerice
    {
        public readonly UnitOfWork _UnitOfWork;

        public ImobilService()
        {
            _UnitOfWork = new UnitOfWork();
        }


        public ImobilEntity GetImobilById(int imobilId)
        {
            var imobil = _UnitOfWork.ImobilRepository.GetByID(imobilId);
            if (imobil!= null)
            {
                Mapper.CreateMap<Imobil, ImobilEntity>();
                var imobilModel = Mapper.Map<Imobil, ImobilEntity>(imobil);
                return imobilModel;
            }
            return null;
        }
       

        public IEnumerable<ImobilEntity> GetAllImobiles()
        {
            var imobil = _UnitOfWork.ImobilRepository.GetAll().ToList();
            if (imobil.Any())
            {
                Mapper.CreateMap<Imobil, ImobilEntity>();
                var imobilModel = Mapper.Map<List<Imobil>, List<ImobilEntity>>(imobil);
                return imobilModel;
            }
            return null;
        }

        public int CreateImobil(ImobilEntity imobilEntity)
        {
            var imobil=new Imobil();
            imobil.denumire_imobil = imobilEntity.denumire_imobil;
            imobil.comentariu = imobil.comentariu;

            _UnitOfWork.ImobilRepository.Insert(imobil);
            _UnitOfWork.Save();
            return imobil.id_imobil;
        }

        public bool UpdateImobil(int imobilId, ImobilEntity imobilEntity)
        {
            var success = false;
            if (imobilEntity != null)
            {
                var imobil = _UnitOfWork.ImobilRepository.GetByID(imobilId);

                if (imobil != null)
                {
                    imobil.denumire_imobil = imobilEntity.denumire_imobil;
                    _UnitOfWork.ImobilRepository.Update(imobil);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteImobil(int imobilId)
        {
            var success = false;
            if (imobilId > 0)
            {
                var imobil = _UnitOfWork.ImobilRepository.GetByID(imobilId);
                if (imobil != null)
                {
                    _UnitOfWork.ImobilRepository.Delete(imobil);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }
    }
}
