using System;
using System.Collections.Generic;
using System.Text;

namespace P01._Class_Box_Data
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Height
        {
            get { return height; }
            private set
            {
                DataValidator.ValidateSide(value, nameof(this.Height));
                height = value;
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                DataValidator.ValidateSide(value, nameof(this.Width));
                width = value;
            }
        }
        public double Length
        {
            get { return length; }
            private set
            {
                DataValidator.ValidateSide(value, nameof(this.Length));
                length = value;
            }
        }

        public string SurfaceArea()
        {
            double area = 2 * (this.length*this.width + this.length * this.height + this.height*this.width);
            return $"Surface Area - {area:f2}";
        }
        public string LateralArea()
        {
            double area = 2 *this.height *(this.length+this.width);
            return $"Surface Area - {area:f2}";
        }

        public string Volume()
        {
            double volume = this.length * this.width * this.height;
            return $"Volume - {volume:f2}";
        }
    }
}
