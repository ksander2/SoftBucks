using System.Data.Entity;


namespace SoftBucksBase.Models
{
    class SbDbInitializer : CreateDatabaseIfNotExists<SoftBucksContext>
    {
        protected override void Seed(SoftBucksContext context)
        {

            StatusBid sb = new StatusBid();
          
            sb.Id = 0;
            sb.BidStatus = "Не оплачен";
            context.StatusBids.Add(sb);

            sb = new StatusBid();
           
            sb.Id = 1;
            sb.BidStatus = "Оплачен";
            context.StatusBids.Add(sb);

            

            Beverage moka = new Beverage();
            moka.Id = 0;
            moka.Name = "Мокачино";
            moka.Cost = 100;

            Beverage expresso = new Beverage();
            expresso.Id = 1;
            expresso.Name = "Экспрессо";
            expresso.Cost = 120;

            Beverage cappuccino = new Beverage();
            cappuccino.Id = 2;
            cappuccino.Name = "Капучино";
            cappuccino.Cost = 150;

            context.Beverages.Add(moka);
            context.Beverages.Add(expresso);
            context.Beverages.Add(cappuccino);

            Condiment sugar = new Condiment();
            sugar.Id = 0;
            sugar.Name = "Сахар";
            sugar.Cost = 10;

            Condiment Chocolate = new Condiment();
            Chocolate.Id = 1;
            Chocolate.Name = "Шоколад";
            Chocolate.Cost = 20;

            Condiment Milk = new Condiment();
            Milk.Id = 2;
            Milk.Name = "Молоко";
            Milk.Cost = 30;

            context.Condiments.Add(sugar);
            context.Condiments.Add(Chocolate);
            context.Condiments.Add(Milk);
           
            base.Seed(context);

        }

    }
}
