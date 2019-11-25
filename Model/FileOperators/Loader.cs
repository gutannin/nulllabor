using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Model.FileOperators
{
    class Loader : IFileOperator
    {
        public void perform(HistoryData data, String argument, IPresenter presenter)
        {
            double[] block = null;

            try
            {
                String s;

                using (StreamReader stream = new StreamReader(argument))
                {
                    s = stream.ReadLine();
                }

                String[] values = s.Split(' ');

                if (values.Length > 1e6)
                {
                    presenter.showStatus(0, "File is too big.");
                    return;
                }

                block = new double[values.Length];

                for (uint i = 0; i < block.Length; ++i)
                {
                    if (!Double.TryParse(values[i], out block[i]))
                    {
                        presenter.showStatus(0, "Parse fail => '" + values[i] + "'");
                        return;
                    }

                    if ((i + 1) % 100 == 0 || i + 1 == block.Length)
                        presenter.showStatus((double)(i + 1) / block.Length, "Performing save.");
                }
            }
            catch (Exception e)
            {
                presenter.showStatus(0, e.ToString());
                return;
            }

            data.Add(block);
            presenter.showStatus(1, "Done.");
            presenter.showHistory(data);
        }
    }
}
