using CoreWebApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using CoreWebApp.DAL.GenericRepository;
using CoreWebApp.DAL.DbSets;
using System.Reflection.Metadata.Ecma335;

namespace CoreWebApp.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private CoreDbContext _context;
        private IGenericRepository<Categories> _categoriesRepo;
        public UnitOfWork(CoreDbContext context,
            IGenericRepository<Categories> CategoryRepository)
        {
            _context = context;
            _categoriesRepo = CategoryRepository;
        }

        
        public IGenericRepository<Categories> CategoriesRepo => _categoriesRepo;








        #region private dispose variable declaration...
        private bool disposed = false;
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


        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }





     #region Implementing IDiosposable...
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
