using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IConcatDal _concatDal;

        public ContactManager(IConcatDal concatDal)
        {
            _concatDal = concatDal;
        }

        public void Delete(Contact t)
        {
            _concatDal.Delete(t);
        }

        public Contact GetById(int id)
        {
            return _concatDal.GetById(id);
        }

        public List<Contact> GetListAll()
        {
           return _concatDal.GetListAll();
        }

        public void Insert(Contact t)
        {
            _concatDal.Insert(t);
        }

        public void Update(Contact t)
        {
            _concatDal.Update(t);
        }
    }
}
