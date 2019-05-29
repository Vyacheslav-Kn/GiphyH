﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFile(IFormFile file);
    }
}