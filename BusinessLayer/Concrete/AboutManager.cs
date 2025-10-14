using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutService;

        public AboutManager(IAboutDal aboutService)
        {
            _aboutService = aboutService;
        }

        public void Delete(About t)
        {
            _aboutService.Delete(t);
        }

        public About GetById(int id)
        {
            return _aboutService.GetById(id);
        }

        public List<About> GetListAll()
        {
            return _aboutService.GetListAll();
        }

        public void Insert(About t)
        {
           _aboutService.Insert(t);
        }

        public void Update(About t)
        {
            _aboutService.Update(t);
        }
    }
}
