﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Model
{
    public class Model : IModel
    {
        private IKernel kernel;
        private IPresenter presenter;
        private HistoryData historyData;
        private SortedDictionary<String, IPerformer> operations;
        public Model(IKernel kernel)
        {
            this.kernel = kernel;
            this.presenter = kernel.Get<IPresenter>();
            this.historyData = new HistoryData();
            this.operations = new SortedDictionary<String, IPerformer>();

            this.operations.Add("plus", new Performers.Plus());
            this.operations.Add("minus", new Performers.Minus());
            this.operations.Add("multiply", new Performers.Multiplier());
            this.operations.Add("divide", new Performers.Divider());

            this.operations.Add("square", new Performers.Square());
            this.operations.Add("sqrt", new Performers.Sqrt());
            this.operations.Add("root", new Performers.Root());
            this.operations.Add("power", new Performers.Power());

            this.operations.Add("log", new Performers.Log());
            this.operations.Add("factorial", new Performers.Factorial());
            this.operations.Add("mean", new Performers.Mean());
            this.operations.Add("stddev", new Performers.StdDev());

            this.operations.Add("clone", new Performers.Cloner());
            //this.operations.Add("factorial", new Performers.Factorial());
            //this.operations.Add("mean", new Performers.Mean());
            //this.operations.Add("stddev", new Performers.StdDev());

            this.operations.Add("assign", new Performers.Assigner());
            this.operations.Add("reset", new Performers.Reset());
            this.operations.Add("undo", new Performers.Undoer());
            this.operations.Add("repeat", new Performers.Repeater());
        }

        public void performOperation(String action, double argument)
        {
            try
            {
                operations[action].perform(historyData, argument, presenter);
                presenter.showHistory(historyData);
            }
            catch (KeyNotFoundException)
            {
                presenter.showStatus(0, "Bad operation.");
            }
        }

        public void fileOperation(String action, String argument)
        {
            if (action == "save")
            {
                new FileOperators.Saver().perform(historyData, argument, presenter);
            }
            else if (action == "load")
            {
                new FileOperators.Loader().perform(historyData, argument, presenter);
            }
        }

        public void restoreHistory(int pointer)
        {
            if (pointer >= historyData.list.Count)
                presenter.showStatus(0, "Bad history point for restoreHistory()");
            else
            {
                historyData.pointer = pointer;
                presenter.showHistory(historyData);
            }
        }
    }
}
