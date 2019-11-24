using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Presentation
{
    class Presenter : Model.IPresenter, Demo.IPresenter
    {
        private IKernel kernel;
        private Model.IModel model;
        private Demo.IView view;

        public Presenter(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public void bind()
        {
            this.model = kernel.Get<Model.IModel>();
            this.view = kernel.Get<Demo.IView>();
        }

        public void performAction(string action, string argument)
        {
            double input;

            if (argument.Length == 0)
                input = 0;
            else if (!Double.TryParse(argument, out input))
            {
                view.showStatus(0, "Bad argument.");
                return;
            }

            model.performOperation(action, input);
        }

        public void restoreHistory(int pointer)
        {
            model.restoreHistory(pointer);
        }

        public void showHistory(Model.HistoryData data)
        {
            var list = new List<String>();

            uint p = 0;
            foreach (var d in data.list)
            {
                String s = p.ToString() + ":" + d.Length.ToString() + " => [";

                ++p;

                for (uint i = 0; i < d.Length; ++i)
                {
                    if (s.Length + d[i].ToString().Length > 130)
                    {
                        s += "...";
                        break;
                    }

                    s += d[i].ToString();

                    if (i + 1 < d.Length)
                        s += ", ";
                }

                s += "]";

                list.Add(s);
            }

            view.showHistory(list, data.pointer);
        }

        public void showStatus(double percent, string status)
        {
            view.showStatus(percent, status);
        }
    }
}
