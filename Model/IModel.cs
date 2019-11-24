using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IModel
    {
        void performOperation(String action, double argument);
        void restoreHistory(int pointer);
    }
}
