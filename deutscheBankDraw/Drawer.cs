using System;
using System.Threading;
using System.Threading.Tasks;
using DeutscheBankDraw.Commands;

namespace DeutscheBankDraw
{
    public class Drawer
    {
        public Drawer()
        {
            this.Canvas = new Canvas();
        }

        public void Paint(ICommand cmd)
        {
            this.Canvas = cmd.Execute(this.Canvas);
        }

        public ICanvas Canvas { get; private set; }

    }


}
