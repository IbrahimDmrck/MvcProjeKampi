﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetAboutList();
        void AddAboutBL(About about);
        About GetByID(int id);
        void AboutDelete(About about);
        void AboutUpdate(About about);
    }
}
