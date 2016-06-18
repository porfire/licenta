using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
    public class DetaliiImobilService : IDetaliiImobilService
    {
        public readonly UnitOfWork _UnitOfWork;

        public DetaliiImobilService()
        {
            _UnitOfWork = new UnitOfWork();
        }

        public DetaliiImobilEntity GetdetailsById(int detailsId)
        {
            var delail = _UnitOfWork.DetaliiImobilRepository.GetByID(detailsId);
            if (delail != null)
            {
                Mapper.CreateMap<DetaliiImobil, DetaliiImobilEntity>();
                var detailModel = Mapper.Map<DetaliiImobil, DetaliiImobilEntity>(delail);
                return detailModel;
            }
            return null;
        }

        public IEnumerable<DetaliiImobilEntity> GetAllPersons()
        {
            var details = _UnitOfWork.DetaliiImobilRepository.GetAll().ToList();
            if (details.Any())
            {
                Mapper.CreateMap<DetaliiImobil, DetaliiImobilEntity>();
                var detailModel = Mapper.Map<List<DetaliiImobil>, List<DetaliiImobilEntity>>(details);
                return detailModel;
            }
            return null;
        }


        public IEnumerable<DetaliiImobilEntity> GetAllDetails()
        {
            var details = _UnitOfWork.DetaliiImobilRepository.GetAll().ToList();
            if (details.Any())
            {
                Mapper.CreateMap<DetaliiImobil, DetaliiImobilEntity>();
                var detailModel = Mapper.Map<List<DetaliiImobil>, List<DetaliiImobilEntity>>(details);
                return detailModel;
            }
            return null;
        }

        public int CreateDetaliiImobil(DetaliiImobilEntity detaliiImobilEntity)
        {
            var detail = new DetaliiImobil();
            {
                detail.detalii_finale_en = detaliiImobilEntity.detalii_finale_en;
                detail.detalii_finale_fr = detaliiImobilEntity.detalii_finale_fr;
                detail.detalii_finale_ro = detaliiImobilEntity.detalii_finale_ro;
                detail.detalii_suplimentare_en = detaliiImobilEntity.detalii_suplimentare_en;
                detail.detalii_suplimentare_fr = detaliiImobilEntity.detalii_suplimentare_fr;
                detail.detalii_suplimentare_ro = detaliiImobilEntity.detalii_suplimentare_ro;
                detail.publica = detaliiImobilEntity.publica;

            }
            _UnitOfWork.DetaliiImobilRepository.Insert(detail);
            _UnitOfWork.Save();
            return detail.detaliiID;
        }

        public bool UpdateDetaliiImobil(int detaliiImobilId, DetaliiImobilEntity detaliiImobilEntity)
        {
            var succes = false;
            if (detaliiImobilEntity != null)
            {
                var detaliiImobil = _UnitOfWork.DetaliiImobilRepository.GetByID(detaliiImobilId);
                if (detaliiImobil != null)
                {
                    detaliiImobil.publica = detaliiImobilEntity.publica;
                    detaliiImobil.detalii_suplimentare_ro = detaliiImobilEntity.detalii_suplimentare_ro;
                    detaliiImobil.detalii_suplimentare_en = detaliiImobilEntity.detalii_suplimentare_en;
                    detaliiImobil.detalii_suplimentare_fr = detaliiImobilEntity.detalii_suplimentare_fr;
                    detaliiImobil.detalii_finale_en = detaliiImobilEntity.detalii_finale_en;
                    detaliiImobil.detalii_finale_fr = detaliiImobilEntity.detalii_finale_fr;
                    detaliiImobil.detalii_finale_ro = detaliiImobilEntity.detalii_finale_ro;

                    _UnitOfWork.DetaliiImobilRepository.Update(detaliiImobil);
                    _UnitOfWork.Save();
                    succes = true;
                }
            }
            return succes;
        }


        public bool DeleteDetaliiImobil(int detaliiImobilId)
        {
            var succes = false;
            if (detaliiImobilId > 0)
            {
                var cartier = _UnitOfWork.DetaliiImobilRepository.GetByID(detaliiImobilId);
                if (cartier != null)
                {
                    _UnitOfWork.CartierRepository.Delete(cartier);
                    _UnitOfWork.Save();
                    succes = true;
                }
            }
            return succes;
        }
    }
}
