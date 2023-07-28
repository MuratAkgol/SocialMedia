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
    public class SocialsManager : IService<Social>
    {
        GenericRepository<Social> _socials = new GenericRepository<Social> ();
        public void Add(Social entity)
        {
            _socials.Insert(entity);
        }

        public void Delete(Social entity)
        {
            _socials.Delete(entity);
        }

        public Social GetById(int id)
        {
            return _socials.Get(x => x.Id == id);
        }

        public List<Social> List()
        {
            return _socials.List();
        }

        public List<Social> List(Expression<Func<Social, bool>> filter)
        {
            return _socials.List();
        }

        public void Update(Social entity)
        {
            _socials.Update(entity);
        }
    }
}
