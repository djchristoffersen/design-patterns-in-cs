﻿using System.Collections.Generic;
using System.Linq;

namespace Wincubate.BuilderLabs
{
    class FluentPizzaBuilder
    {
        private Pizza _pizza;

        public FluentPizzaBuilder Begin()
        {
            _pizza = new Pizza();
            _pizza.Toppings = new List<ToppingKind>();

            return this;
        }

        public FluentPizzaBuilder WithCrust( CrustKind crust )
        {
            _pizza.Crust = crust;

            return this;
        }

        public FluentPizzaBuilder Sauce
        {
            get
            {
                _pizza.HasSauce = true;

                return this;
            }
        }

        public FluentPizzaBuilder AddCheese( CheeseKind cheese = CheeseKind.Regular )
        {
            _pizza.Cheese = cheese;

            return this;
        }

        public FluentPizzaBuilder Oregano
        {
            get
            {
                _pizza.Oregano = true;

                return this;
            }
        }

        public FluentPizzaBuilder AddTopping( ToppingKind topping )
        {
            IEnumerable<ToppingKind> existingToppings = _pizza.Toppings;
            _pizza.Toppings = existingToppings.Union( new ToppingKind[] { topping });

            return this;
        }

        public Pizza Build() => _pizza;
    }
}
