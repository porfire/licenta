using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
    public class OfertaService : IOfertaService
    {
        public readonly UnitOfWork _UnitOfWork;

        public OfertaService()
        {
            _UnitOfWork=new UnitOfWork();
        }
        public OfertaEntity GetOfertaById(int ofertaId)
        {
            var oferta = _UnitOfWork.OfertaRepository.GetByID(ofertaId);
            if (oferta != null)
            {
                Mapper.CreateMap<Oferta, OfertaEntity>();
                var ofertaModel = Mapper.Map<Oferta, OfertaEntity>(oferta);
                return ofertaModel;
            }
            return null;
        }

        public IEnumerable<OfertaEntity> GetAllOfertas()
        {
            var oferta = _UnitOfWork.OfertaRepository.GetAll().ToList();
            if (oferta.Any())
            {
                Mapper.CreateMap<Oferta, OfertaEntity>();
                var ofertaModel = Mapper.Map<List<Oferta>,List<OfertaEntity>>(oferta);
                return ofertaModel;
            }
            return null;
        }

        public int CreateOferta(OfertaEntity ofertaEntity)
        {
            var oferta = new Oferta();
          
            oferta.an_constructie = ofertaEntity.an_constructie;
            oferta.nr_bai = ofertaEntity.nr_bai;
            oferta.nr_balcoane = ofertaEntity.nr_balcoane;
            oferta.nr_bucatarii = ofertaEntity.nr_camere;
            oferta.climatizare = ofertaEntity.climatizare;
            oferta.compartimentare = ofertaEntity.compartimentare;
            oferta.confort = ofertaEntity.confort;
            oferta.etaj = ofertaEntity.etaj;
            oferta.ferestre = ofertaEntity.ferestre;
            oferta.internet = ofertaEntity.internet;
            oferta.loc_parcare = ofertaEntity.loc_parcare;
            oferta.mobilat = ofertaEntity.mobilat;
            oferta.moneda = ofertaEntity.moneda;
            oferta.nr_camere = ofertaEntity.nr_bucatarii;
            oferta.pret = ofertaEntity.pret;
            oferta.podele = ofertaEntity.podele;
        
            oferta.sistem_incalzire = ofertaEntity.sistem_incalzire;
            oferta.stare_interior = ofertaEntity.stare_interior;
            oferta.suprafata_utila = ofertaEntity.suprafata_utila;
            oferta.tip_contact = ofertaEntity.tip_contact;
            oferta.usa_intrare = ofertaEntity.usa_intrare;
            oferta.utilitati_gen = ofertaEntity.utilitati_gen;
            oferta.latitudine = ofertaEntity.latitudine;
            oferta.longitudine = ofertaEntity.longitudine;

            _UnitOfWork.OfertaRepository.Insert(oferta);
            _UnitOfWork.Save();
            return oferta.id_oferta;
        }

        
        public bool UpdateOferta(int ofertaId, OfertaEntity ofertaEntity)
        {
        var success = false;
        if (ofertaEntity != null)
        {
            var oferta = _UnitOfWork.OfertaRepository.GetByID(ofertaId);

            if (oferta != null)
            {
                    oferta.an_constructie = ofertaEntity.an_constructie;
                    oferta.nr_bai = ofertaEntity.nr_bai;
                    oferta.nr_balcoane = ofertaEntity.nr_balcoane;
                    oferta.nr_bucatarii = ofertaEntity.nr_camere;
                    oferta.climatizare = ofertaEntity.climatizare;
                    oferta.compartimentare = ofertaEntity.compartimentare;
                    oferta.confort = ofertaEntity.confort;
                    oferta.etaj = ofertaEntity.etaj;
                    oferta.ferestre = ofertaEntity.ferestre;
                    oferta.internet = ofertaEntity.internet;
                    oferta.loc_parcare = ofertaEntity.loc_parcare;
                    oferta.mobilat = ofertaEntity.mobilat;
                    oferta.moneda = ofertaEntity.moneda;
                    oferta.nr_camere = ofertaEntity.nr_bucatarii;
                    oferta.pret = ofertaEntity.pret;
                    oferta.podele = ofertaEntity.podele;

                    oferta.sistem_incalzire = ofertaEntity.sistem_incalzire;
                    oferta.stare_interior = ofertaEntity.stare_interior;
                    oferta.suprafata_utila = ofertaEntity.suprafata_utila;
                    oferta.tip_contact = ofertaEntity.tip_contact;
                    oferta.usa_intrare = ofertaEntity.usa_intrare;
                    oferta.utilitati_gen = ofertaEntity.utilitati_gen;
                    oferta.latitudine = ofertaEntity.latitudine;
                    oferta.longitudine = ofertaEntity.longitudine;

                    _UnitOfWork.OfertaRepository.Update(oferta);
                _UnitOfWork.Save();
                success = true;
            }
        }
        return success;
    }

        public bool DeleteOferta(int ofertaId)
        {

            var success = false;
            if (ofertaId > 0)
            {
                var oferta = _UnitOfWork.OfertaRepository.GetByID(ofertaId);
                if (oferta != null)
                {
                    _UnitOfWork.OfertaRepository.Delete(oferta);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }
    }
}
