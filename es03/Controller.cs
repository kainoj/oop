using System;
using System.Collections.Generic;

namespace Controller {

    class OneClickBuyHandler {

        OneClickBuyController oneClickBuyController;
        
        public OneClickBuyHandler() {
            this.oneClickBuyController = new OneClickBuyController();
        }
        public void oneClickBuy(List <string> items) {
            Console.WriteLine("One click buy process has started...");
            oneClickBuyController.buy(items);
            Console.WriteLine("...bought successfully!");
        }

    }
    
    class OneClickBuyController {
        Cart cart;
        Bank bank;

        public OneClickBuyController() {
            cart = new Cart();
            bank = new Bank();
        }

        public void buy(List<string> items) {
            cart.addToCart(items);
            while(!bank.moneyTransfer());
            cart.emptyCart();
        }
    }

    class Cart {
        private List<string> cart;
        
        public Cart() {
            this.cart = new List<string>();
        }

        public void addToCart(List<string> items) {
            this.cart.AddRange(items);
        }

        public void emptyCart() {
            this.cart.Clear();
        }

    }

    class Bank {
        public bool moneyTransfer() {
            Console.WriteLine("sending money...");
            return true;
        }
    }
}