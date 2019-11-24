using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Performers
{
    class Assign : IPerformer
    {
        public void perform(HistoryData data, double input, IPresenter presenter)
        {
            double[] block = new double[1] { input };

            data.Add(block);
            presenter.showStatus(1, "Done.");
        }
    }
}
