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
    public class UserManager : IService<User>
    {
        GenericRepository<User> _user = new GenericRepository<User>();
        public void Add(User entity)
        {
            _user.Insert(entity);
        }

        public void Delete(User entity)
        {
            _user.Delete(entity);
        }

        public User GetById(int id)
        {
            return _user.Get(x => x.Id == id);
        }

        public List<User> List()
        {
            return _user.List();
        }

        public List<User> List(Expression<Func<User, bool>> filter)
        {
            return _user.List();
        }

        public void Update(User entity)
        {
            _user.Update(entity);
        }
    }
}
