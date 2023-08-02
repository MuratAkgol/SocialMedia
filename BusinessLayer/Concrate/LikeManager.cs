using BusinessLayer.Abstract;
using DataLayer.GenericRepository;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class LikeManager : IService<Likes>
    {
        GenericRepository<Likes> _likes = new GenericRepository<Likes>();
        public void Add(Likes entity)
        {
            _likes.Insert(entity);
        }

        public void Delete(Likes entity)
        {
            _likes.Delete(entity);
        }

        public Likes GetById(int id)
        {
            return _likes.Get(x => x.Social == id);
        }

        public List<Likes> List()
        {
            return _likes.List();
        }

        public List<Likes> List(Expression<Func<Likes, bool>> filter)
        {
            return _likes.List();
        }

        public void Update(Likes entity)
        {
            _likes.Update(entity);
        }
    }
}
