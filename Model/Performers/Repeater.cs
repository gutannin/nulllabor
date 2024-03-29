﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Performers
{
    class Repeater : IPerformer
    {
        public void perform(HistoryData data, double input, IPresenter presenter)
        {
            if (data.list.Count == 0 || data.pointer + 1 == data.list.Count)
            {
                presenter.showStatus(0, "Bad state.");
                return;
            }

            data.pointer++;
            presenter.showStatus(1, "Done.");
        }
    }
}
