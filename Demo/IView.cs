using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public interface IView
    {
        void showStatus(double percent, String status);
        void showHistory(List<String> data, int pointer);
    }
}
