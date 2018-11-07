using System;

namespace Ericson.AmriAnswers.Question2
{
    // just a note, since i finished my highschool in other than english, so term "phase" wasn't known to me. 
    // with google help also, still i couldn't find a definition for the term.
    // a vector can be sum in two way, by x,y and magnitude and degree between them. i tried many different keyword but still i couldn't find anything regard to vector and phase. 
    // so in this solution i only cover the sum based on magnitude and degree between the magnitude, hope you ignore the lack if there is any!
    public class Vector
    {
        private double _degree;
        public double Magnitude { get; set; }

        /// <summary>
        ///     i assumed the degree of each vector is from a portion of 360.
        ///     for more info look at the "https://www.physicsclassroom.com/class/vectors/Lesson-1/Vector-Addition"
        ///     head-to-tail section
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double Degree
        {
            get => _degree;
            set
            {
                if (value > 360 || value < -360) throw new ArgumentException("the value can't be more than 360 degree");
                _degree = value;
            }
        }

        public static Vector operator +(Vector u, Vector v)
        {
            // in a normal program i woudlnt clutter a function with a lot of delegate. every of these delegates should go into a helper or relavant class 
            // but usually i follow the "rule of 3". a function should be needed more than 3 times to make it available inside a class. 
            // so here i only need it once and only in this example, so i used the "in-method functions". performance wise it doesn't affect since IL will convert theme to anonymous function on build. it only keep the 
            // class API cleaner

            var convertToRadiant = new Func<double, double>(d => d * (Math.PI / 180.0));
            var convertToDegree = new Func<double, double>(r => r * (180.0 / Math.PI));
            
            var degreeBetweenTwoLine = new Func<double, double, double>((d1, d2) =>
            {
                //https://www.youtube.com/watch?v=ILzOxUNXuSs
                var m1 = Math.Tan(convertToRadiant(d1));
                var m2 = Math.Tan(convertToRadiant(d2));
                var tanFi = -1 * ((m1 - m2) / (1 + m1 * m2));
                var fi = Math.Atan(tanFi);
                var degree = convertToDegree(fi);
                if (degree < 0) return 180 + degree;

                return degree;
            });
            
            //c^2=a^2+b^2-2abCos0  https://www.youtube.com/watch?v=8YsMNFWvgpk
            var c = new Func<double, double, double, double>((a, b, degree) =>
                Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 2 * a * b * Math.Cos(convertToRadiant(degree))));

            var degreeBetween = degreeBetweenTwoLine(u.Degree, v.Degree);

            if ((int) degreeBetween == 0)
                return new Vector
                {
                    Magnitude = Math.Cos(convertToRadiant(u.Degree)) * u.Magnitude +
                                Math.Cos(convertToRadiant(v.Degree)) * v.Magnitude,
                    Degree = u.Degree
                };

            var cResult = c(u.Magnitude, v.Magnitude, degreeBetween);

            var degreeBetweenSumAndStartPoint = (int) cResult == 0
                ? 0
                : convertToDegree(Math.Asin(v.Magnitude * Math.Sin(convertToRadiant(degreeBetween)) / cResult));

            var degreeRespectToStartPoint = Math.Round(u.Degree - degreeBetweenSumAndStartPoint, 0);

            var degreeRespectToStartPointPositive = degreeRespectToStartPoint < 0
                ? 360 + degreeRespectToStartPoint
                : degreeRespectToStartPoint;

            return new Vector
            {
                Magnitude = Math.Round(cResult, 2),
                Degree = degreeRespectToStartPointPositive
            };
        }
    }
}
