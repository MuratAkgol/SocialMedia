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
    public class CommentManager : IService<Comments>
    {
        GenericRepository<Comments> _comments = new GenericRepository<Comments>();
        public void Add(Comments entity)
        {
            _comments.Insert(entity);
        }

        public void Delete(Comments entity)
        {
            _comments.Delete(entity);
        }

        public Comments GetById(int id)
        {
            return _comments.Get(x=>x.Id == id);
        }

        public List<Comments> List()
        {
            return _comments.List();
        }

        public List<Comments> List(Expression<Func<Comments, bool>> filter)
        {
            return _comments.List();
        }

        public void Update(Comments entity)
        {
            _comments.Update(entity);
        }
    }
}
