﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business
{
    public interface IMemberBusinessSerive
    {
        void CreateBorrower(AddMemberVM model);
    }
}
