using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;
using System.IO;

namespace BusinessServices.Services
{
    public class FotoImobilServce : IFotoImobilService
    {
        public readonly UnitOfWork _UnitOfWork;

        public FotoImobilServce()
        {
            _UnitOfWork = new UnitOfWork();
        }

        public FotoImobilEntity GetFotoImobilById(int fotoImobilId)
        {
            var fotoImobil = _UnitOfWork.FotoImobilRepository.GetByID(fotoImobilId);
            if (fotoImobil != null)
            {
                Mapper.CreateMap<FotoImobil, FotoImobilEntity>();
                var fotoImobilModel = Mapper.Map<FotoImobil, FotoImobilEntity>(fotoImobil);
                return fotoImobilModel;
            }
            return null;
        }

        public IEnumerable<FotoImobilEntity> GetAllFotos()
        {
            var fotoImobils = _UnitOfWork.FotoImobilRepository.GetAll().ToList();
            if (fotoImobils.Any())
            {
                Mapper.CreateMap<FotoImobil, FotoImobilEntity>();
                var FotoImobilModel = Mapper.Map<List<FotoImobil>, List<FotoImobilEntity>>(fotoImobils);
                return FotoImobilModel;
            }
            return null;
        }

        public int CreateFotoImobil(FotoImobilEntity fotoImobilEntity)
        {
            var fotoImobil = new FotoImobil();
            {
                fotoImobil.NumeFoto = fotoImobilEntity.NumeFoto;
                fotoImobil.DescriereFoto = fotoImobilEntity.DescriereFoto;
              
            }
            _UnitOfWork.FotoImobilRepository.Insert(fotoImobil);
            _UnitOfWork.Save();
             return fotoImobil.fotoID;
        }

        public bool UpdateFotoImobil(int fotoImobilId, FotoImobilEntity fotoImobilEntity)
        {
            var success = false;
            if (fotoImobilEntity != null)
            {
                    var fotoImobil = _UnitOfWork.FotoImobilRepository.GetByID(fotoImobilId);

                    if (fotoImobil != null)
                    {
                        fotoImobil.NumeFoto = fotoImobilEntity.NumeFoto;
                        fotoImobil.DescriereFoto = fotoImobilEntity.NumeFoto;
                      
                        _UnitOfWork.FotoImobilRepository.Update(fotoImobil);
                        _UnitOfWork.Save();
                        success = true;
                    }
                }
            return success;
        }

        public bool DeleteFotoImobil(int fotoImobilId)
        {

            var success = false;
            if (fotoImobilId > 0)
            {
                var fotoImobil = _UnitOfWork.FotoImobilRepository.GetByID(fotoImobilId);
                if (fotoImobil != null)
                {
                    _UnitOfWork.FotoImobilRepository.Delete(fotoImobil);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }
        public byte[] GetFile(string storagePath)  //asta o sa iti returneze un byte array dintr-run path care il dai 
        {
            FileStream fileStream = null;

            try
            {
                //fileStream = new FileStream(storagePath, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, true);
                var file = new byte[fileStream.Length];
                fileStream.Read(file, 0, (int)fileStream.Length);
                return file;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }
    }
}
