﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibCafe
{
    public delegate void PintStartedHandler(object sender, EventArgs e);
    public delegate void PintCompletedHandler(object sender, PintCompletedArgs e);
    public delegate void DishHalfwayHandler(object sender, EventArgs e);
    public delegate void DishCompletedHandler(object sender, EventArgs e);

    public class PintDish
    {
        public event PintStartedHandler PintStarted;
        public event PintCompletedHandler PintCompleted;
        public event DishHalfwayHandler DishHalfway;
        public event DishCompletedHandler DishCompleted;

        private int pintCount;
        
        public int PintCount { get { return pintCount; } } // c#6.0 enkel get in property: set enkel in constructor
        public int MaxPints { get; }

        public PintDish(int maxPints)
        {
            MaxPints = maxPints;
        }

        public void AddPint()
        {
            if (pintCount >= MaxPints) throw new Exception("Dish full, order cancelled");
            PintStarted?.Invoke(this, EventArgs.Empty);
            pintCount++;
            PintCompleted?.Invoke(this, new PintCompletedArgs());
            if ((Math.Ceiling(Convert.ToDecimal(MaxPints / 2)) == pintCount))
                DishHalfway?.Invoke(this, EventArgs.Empty);
           if (pintCount == MaxPints) DishCompleted?.Invoke(this, EventArgs.Empty);    

        }
    }


    public class PintCompletedArgs : EventArgs
    {
        private static string[] Brands = { "Cara Pils", "Jupiler", "Stella Artois", "Bavik" };
        private static string[] Waiters = { "Jeff", "Carine", "Billy", "Julie" };
        public static Random random = new Random();

        public string Brand { get; }
        public string Waiter { get; }

        public PintCompletedArgs()
        {
            Brand = Brands[random.Next(0, Brands.Length)];
            Waiter = Waiters[random.Next(0, Waiters.Length)];
        }
    }
}
