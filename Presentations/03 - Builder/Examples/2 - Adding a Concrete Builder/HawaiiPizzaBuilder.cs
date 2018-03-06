using System.Collections.Generic;

namespace Wincubate.BuilderExamples
{
    class HawaiiPizzaBuilder
    {
        public Pizza Product => _pizza;
        private Pizza _pizza;

        public HawaiiPizzaBuilder()
        {
            _pizza = new Pizza();
        }

        public void Build()
        {
            CreateCrust();
            AddToppings();
            AddSpices();
        }

        private void CreateCrust()
        {
            _pizza.Crust = CrustKind.Classic;
            _pizza.HasSauce = true;
            _pizza.Cheese = CheeseKind.Regular;
        }

        private void AddToppings()
        {
            _pizza.Toppings = new List<ToppingKind>
            {
                ToppingKind.Ham,
                ToppingKind.Pineapple
            };
        }

        private void AddSpices()
        {
            _pizza.Oregano = true;
        }
    }
}