using System;

// Ex2a refactored according to Open-Close Principle
namespace Ex3b {

    public interface Item {
        Decimal Price { get; }
        string Name { get; }
        int Tax {get; }
    }

    public class TaxCalculator {
        public Decimal CalculateTax(Item item) { 
            // Handle some exceptions, eg item is freed form tax, etc
            return item.Price * item.Tax / 100;
        }
    }

    public class BillEntryGenerator {
        private TaxCalculator taxCalc;
        public BillEntryGenerator(TaxCalculator taxCalc) {
            this.taxCalc = taxCalc;
        }
        public string getBillEntry(Item item) {
            if (item.Price == 0)
                return string.Format("{0} is a gift!", item.Name);
            return string.Format("towar {0} : cena {1} + podatek {2}", 
                     item.Name, item.Price, taxCalc.CalculateTax( item ));

        }

    }

    
    public class CashRegister {

        public TaxCalculator taxCalc;
        public BillEntryGenerator billEntry;

        public CashRegister() {
            this.taxCalc = new TaxCalculator();
            this.billEntry = new BillEntryGenerator(this.taxCalc);
        }

        public Decimal CalculatePrice( Item[] Items ) {
            Decimal _price = 0;
            foreach (Item item in Items) {
                _price += item.Price + taxCalc.CalculateTax(item);
            }
            return _price;
        }
        
        public string PrintBill( Item[] Items ) {
            string bill = "";
            foreach ( var item in Items )
                bill += billEntry.getBillEntry(item);
            return bill;
        }
    }
}