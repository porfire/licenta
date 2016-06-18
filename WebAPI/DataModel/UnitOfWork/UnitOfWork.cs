using DataModel.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DataModel.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable,IUnitOfWork
    {
        #region Private member variables...

        private AgentieImobiliaraEntities _context = null;
        private GenericRepository<Person> _personRepository;
        private GenericRepository<Agenti> _agentiRepository;
        private GenericRepository<UserRol> _userRolRepository;
        private GenericRepository<VideoImobil> _videoImobilRepository;
        private GenericRepository<Imobil> _imobilRepository;
        private GenericRepository<Oferta> _ofertaRepository;
        private GenericRepository<Localitate> _localitateRepository;
        private GenericRepository<DetaliiImobil> _detaliiImobilRepository;
        private GenericRepository<FotoImobil> _fotoImobilRepository;
        private GenericRepository<Cartier> _cartierRepository;
        private GenericRepository<Agentie> _agentieRepository;
        private GenericRepository<Token> _tokenRepository;


        #endregion

        public UnitOfWork()
        {
            _context = new AgentieImobiliaraEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for Agenti repository.
        /// </summary>
        public GenericRepository<Agenti> AgentiRepository
        {
            get
            {
                if (this._agentiRepository == null)
                    this._agentiRepository = new GenericRepository<Agenti>(_context);
                return _agentiRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Person repository.
        /// </summary>
        public GenericRepository<Person> PersonRepository
        {
            get
            {
                if (this._personRepository == null)
                    this._personRepository = new GenericRepository<Person>(_context);
                return _personRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for UserRol repository.
        /// </summary>
        public GenericRepository<UserRol> UserRolRepository
        {
            get
            {
                if (this._userRolRepository == null)
                    this._userRolRepository = new GenericRepository<UserRol>(_context);
                return _userRolRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Agentie repository.
        /// </summary>
        public GenericRepository<Agentie> AgentieRepository
        {
            get
            {
                if (this._agentieRepository == null)
                    this._agentieRepository = new GenericRepository<Agentie>(_context);
                return _agentieRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Cartier repository.
        /// </summary>
        public GenericRepository<Cartier> CartierRepository
        {
            get
            {
                if (this._cartierRepository == null)
                    this._cartierRepository = new GenericRepository<Cartier>(_context);
                return _cartierRepository;
            }
        }


        /// <summary>
        /// Get/Set Property for Agentie repository.
        /// </summary>
        public GenericRepository<Localitate> LocalitateRepository
        {
            get
            {
                if (this._localitateRepository == null)
                    this._localitateRepository = new GenericRepository<Localitate>(_context);
                return _localitateRepository;
            }
        }


        /// <summary>
        /// Get/Set Property for Agentie repository.
        /// </summary>
        public GenericRepository<DetaliiImobil> DetaliiImobilRepository
        {
            get
            {
                if (this._detaliiImobilRepository == null)
                    this._detaliiImobilRepository = new GenericRepository<DetaliiImobil>(_context);
                return _detaliiImobilRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for FotoImobil repository.
        /// </summary>
        public GenericRepository<FotoImobil> FotoImobilRepository
        {
            get
            {
                if (this._fotoImobilRepository == null)
                    this._fotoImobilRepository = new GenericRepository<FotoImobil>(_context);
                return _fotoImobilRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for FotoImobil repository.
        /// </summary>
        public GenericRepository<Imobil> ImobilRepository
        {
            get
            {
                if (this._imobilRepository == null)
                    this._imobilRepository = new GenericRepository<Imobil>(_context);
                return _imobilRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for FotoImobil repository.
        /// </summary>
        public GenericRepository<Oferta> OfertaRepository
        {
            get
            {
                if (this._ofertaRepository == null)
                    this._ofertaRepository = new GenericRepository<Oferta>(_context);
                return _ofertaRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for VideoImobil repository.
        /// </summary>
        public GenericRepository<VideoImobil> VideoImobilRepository
        {
            get
            {
                if (this._videoImobilRepository == null)
                    this._videoImobilRepository = new GenericRepository<VideoImobil>(_context);
                return _videoImobilRepository;
            }
        }


        /// <summary>
        /// Get/Set Property for Token repository.
        /// </summary>
        public GenericRepository<Token> TokenRepository
        {
            get
            {
                if(this._tokenRepository ==null)
                    this._tokenRepository =new GenericRepository<Token>(_context);
                return _tokenRepository;
            }
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
       
        #endregion
    }
}