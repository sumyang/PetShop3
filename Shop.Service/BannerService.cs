﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;
using Shop.IService;
using Shop.IRepository;

namespace Shop.Service
{
    public class BannerService : BaseService<Banner>, IBannerService
    {
        public BannerService(IBaseRepository<Banner> baseRepositroy) : base(baseRepositroy)
        {
        }
    }
}
