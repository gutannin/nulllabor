﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public delegate void SomeAction();

    interface IPerformer
    {
        void perform(HistoryData data, double input, IPresenter presenter);
    }
}
