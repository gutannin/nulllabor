using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public interface IPresenter
    {
        void performAction(String action, String argument);

        void fileOperation(String action, String argument);
        void restoreHistory(int pointer);
    }
}
