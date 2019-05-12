using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DeutscheBankDraw
{
    public interface ICanvas
    {
        int Width { get; }
        int Height { get; }
        char[,] Data { get; }
        char Element(int col, int row);
        void SetElement(int col, int row, char input);
    }

    public class Canvas : ICanvas
    {
        private Char[,] data;

        public Canvas() : this(0, 0)
        {

        }

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            this.data = new Char[width, height];
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public char Element(int x, int y)
        {
            return this.data[x, y];
        }

        public void SetElement(int x, int y, char input)
        {
            this.data[x, y] = input;
        }

        public char[,] Data { get { return this.data; } }

    }
}
