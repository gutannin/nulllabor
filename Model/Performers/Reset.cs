using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Performers
{
    class Reset : IPerformer
    {
        public void perform(HistoryData data, double input, IPresenter presenter)
        {
            data.Reset();
            presenter.showStatus(1, "Done.");
        }
    }
}
