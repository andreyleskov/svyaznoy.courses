using System;
using System.Collections.Generic;

namespace Builder
{

    public class Programm
    {
        public static void Main()
        {
            // Create LabelDirector and builders
            LabelDirector labelDirector = new LabelDirector();

            //IBuilder b1 = new SpecialSalesLabelBuilder(DateTime.Now);
            IBuilder b1 = new SpecialSalesLabelBuilder(new DateTime(2014,1,1));
            IBuilder b2 = new CommonLabelBuilder();

            
            labelDirector.ConstructBeerLabel(b1);
            ProductLabel p1 = b1.GetResult();
            p1.Show();
            Console.WriteLine();

            labelDirector.ConstructBeerLabel(b2);
            ProductLabel p2 = b2.GetResult();
            p2.Show();

            // Wait for user
            Console.Read();
        }
    }
}