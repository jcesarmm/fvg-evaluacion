using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Promociones.Domain.Entities.Common;
using MongoDB.Bson;

namespace Promociones.Infrastructure.Common
{
    public abstract class RepositorioGenericoMongoDB<T> : IRepositorioGenerico<T> where T : Entidad
    {
        IMongoDatabase _db;
        IMongoCollection<T> _collection;

        public RepositorioGenericoMongoDB(IMongoClient mongoClient)
        {
            //_client = new MongoClient("mongodb://localhost:27017");
            _db = mongoClient.GetDatabase("PromocionesDB");
            _collection = _db.GetCollection<T>(typeof(T).Name);
        }
        public void Actualizar(T entity)
        {
            if (entity is EntidadAuditable)
            {
                var entidadAuditable = entity as EntidadAuditable;
                entidadAuditable.FechaModificacion = DateTime.Now;
            }

            var operation = Update<T>.Replace(entity);
            var result = _collection.ReplaceOne(
                                Builders<T>.Filter.Eq("Id", entity.Id),
                                entity
                                );
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> filtro)
        {
            return _collection.AsQueryable().Where(filtro.Compile());
        }

        public void Eliminar(T entity)
        {
            _collection.DeleteOne(Builders<T>.Filter.Eq("Id", entity.Id));
        }

        public void Insertar(T entity)
        {
            if (entity is EntidadAuditable)
            {
                var entidadAuditable = entity as EntidadAuditable;
                entidadAuditable.FechaCreacion = DateTime.Now;
            }
            _collection.InsertOne(entity);
        }

        public IEnumerable<T> ObtenerTodos()
        {
            return _collection.AsQueryable().AsEnumerable();
        }

        public int GuardarCambios()
        {
            throw new NotImplementedException();
        }

        public T ObtenerPorId(object id)
        {
            return _collection.Find(f => f.Id == id).FirstOrDefault();
        }
    }
}
