﻿using Entities;
using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContentRepository : RepositoryBase<Content>, IContentRepository
    {
        public ContentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }


    }

}
