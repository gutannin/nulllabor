﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Performers
{
    class Log : IPerformer
    {
        public void perform(HistoryData data, double input, IPresenter presenter)
        {
            if (data.list.Count == 0)
            {
                presenter.showStatus(0, "");
                return;
            }

            if (input <= 0)
            {
                presenter.showStatus(0, "Bad argument.");
                return;
            }

            double[] old = data.Current();
            double[] block = new double[old.Length];

            for (uint i = 0; i < block.Length; ++i)
            {
                if (old[i] <= 0)
                {
                    presenter.showStatus(0, "Bad number.");
                    return;
                }

                block[i] = old[i] + input;

                if ((i + 1) % 100 == 0 || i + 1 == block.Length)
                    presenter.showStatus((double)(i + 1) / block.Length, "Performing log.");
            }

            data.Add(block);
            presenter.showStatus(1, "Done.");
        }
    }
}
