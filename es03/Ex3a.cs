using System;

namespace Ex3a {

    public class TaxCalculator {
        public Decimal CalculateTax( Decimal Price ) { 
            return Price * 22 / 100;
        }
    }
    public class Item {
        public Decimal Price { get; }

        public string Name { get; }
    }
    
    public class CashRegister {

        public TaxCalculator taxCalc = new TaxCalculator();
        
        public Decimal CalculatePrice( Item[] Items ) {
            Decimal _price = 0;
            foreach ( Item item in Items ) {
                _price += item.Price + taxCalc.CalculateTax( item.Price );
            }
            return _price;
        }
        
        public string PrintBill( Item[] Items ) {
            string bill = "";
            foreach ( var item in Items )
                bill += string.Format("towar {0} : cena {1} + podatek {2}", 
                     item.Name, item.Price, taxCalc.CalculateTax( item.Price ));
            return bill;
        }
    }
}