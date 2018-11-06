namespace Ericson.AmriAnswers.Question1
{
    public class Square
    {
        private readonly int _side;

        //it's not a good way since it's against the DI but since it's not part of the requirement i leave it as it
        public Square(int side)
        {
            _side = side;
        }

        public int Perimeter()
        {
            return 4 * _side;
        }

        public int Surface()
        {
            return _side * _side;
        }

        public override string ToString()
        {
            return $"the square has Perimeter: {Perimeter()} & Surface: {Surface()}";
        }
    }
}