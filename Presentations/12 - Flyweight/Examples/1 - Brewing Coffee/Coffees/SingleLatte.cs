namespace Wincubate.FlyweightExamples
{
    class SingleLatte : Coffee
    {
        public SingleLatte( string customerName )
            : base( CoffeeKind.Latte, 1, CoffeeSize.Regular, customerName)
        {
        }
    }
}
